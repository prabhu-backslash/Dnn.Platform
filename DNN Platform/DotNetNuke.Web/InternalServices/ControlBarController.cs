#region Copyright

// DotNetNukeŽ - http://www.dotnetnuke.com
// Copyright (c) 2002-2014
// by DotNetNuke Corporation
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
// to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or substantial portions 
// of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
// TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE.

#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Definitions;
using DotNetNuke.Entities.Tabs;
using DotNetNuke.Entities.Users;
using DotNetNuke.Instrumentation;
using DotNetNuke.Security.Permissions;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Installer.Packages;
using DotNetNuke.Services.Localization;
using DotNetNuke.Services.Log.EventLog;
using DotNetNuke.Web.Api;
using DotNetNuke.Web.Api.Internal;
using DotNetNuke.Web.Client.ClientResourceManagement;

namespace DotNetNuke.Web.InternalServices
{
    [DnnAuthorize]
    public class ControlBarController : DnnApiController
    {
    	private static readonly ILog Logger = LoggerSource.Instance.GetLogger(typeof (ControlBarController));
        private const string DefaultExtensionImage = "icon_extensions_32px.png";
        private readonly Components.Controllers.IControlBarController Controller;
		private IDictionary<string, string> _nameDics;

        public ControlBarController()
        {
            Controller = Components.Controllers.ControlBarController.Instance;
        }

        public class ModuleDefDTO
        {
			public int DesktopModuleID { get; set; }
            public int ModuleID { get; set; }
            public string ModuleName { get; set; }
            public string ModuleImage { get; set; }
            public bool Bookmarked { get; set; }
            public bool ExistsInBookmarkCategory { get; set; }
        }

        public class PageDefDTO
        {
            public int TabID { get; set; }
            public string IndentedTabName { get; set; }
        }

        public class AddModuleDTO
        {
            public string Visibility { get; set; }
            public string Position { get; set; }
            public string Module { get; set; }
            public string Page { get; set; }
            public string Pane { get; set; }
            public string AddExistingModule { get; set; }
            public string CopyModule { get; set; }
            public string Sort { get; set; }
        }

        public class UserModeDTO
        {
            public string UserMode { get; set; }
        }

        public class SwitchSiteDTO
        {
            public string Site { get; set; }
        }

        public class SwitchLanguageDTO
        {
            public string Language { get; set; }
        }

		[HttpGet]
		[DnnPageEditor]
		public HttpResponseMessage GetPortalDesktopModules(string category, int loadingStartIndex, int loadingPageSize, string searchTerm, string excludeCategories = "", bool sortBookmarks = false, string topModule = "")
		{
			if (string.IsNullOrEmpty(category))
			{
				category = "All";
			}
			var bookmarCategory = Controller.GetBookmarkCategory(PortalSettings.Current.PortalId);
			var bookmarkedModules = Controller.GetBookmarkedDesktopModules(PortalSettings.Current.PortalId, UserController.Instance.GetCurrentUserInfo().UserID, searchTerm);
			var bookmarkCategoryModules = Controller.GetCategoryDesktopModules(PortalSettings.PortalId, bookmarCategory, searchTerm);

			var filteredList = bookmarCategory == category ? bookmarkCategoryModules.OrderBy(m => m.Key).Union(bookmarkedModules.OrderBy(m => m.Key)).Distinct()
											: Controller.GetCategoryDesktopModules(PortalSettings.PortalId, category, searchTerm).OrderBy(m => m.Key);

			if (!string.IsNullOrEmpty(excludeCategories))
			{
				var excludeList = excludeCategories.ToLowerInvariant().Split(',');
				filteredList =
					filteredList.Where(kvp =>
						!excludeList.Contains(kvp.Value.DesktopModule.Category.ToLowerInvariant()));
			}
			if (sortBookmarks)
			{
				//sort bookmarked modules
				filteredList = bookmarkedModules.OrderBy(m => m.Key).Concat(filteredList.Except(bookmarkedModules));
				//move Html on top
				filteredList = (filteredList.Where(m => m.Key.ToLowerInvariant() == topModule.ToLowerInvariant())).
								Concat(filteredList.Except((filteredList.Where(m => m.Key.ToLowerInvariant() == topModule.ToLowerInvariant()))));
			}

			List<ModuleDefDTO> modules = new List<ModuleDefDTO>();
			foreach (var kvp in filteredList)
			{			
				foreach (var moduleDefPair in ModuleDefinitionController.GetModuleDefinitionsByDesktopModuleID(kvp.Value.DesktopModuleID).OrderBy(md => md.Value.FriendlyName))
				{
					var moduleDefDTO = new ModuleDefDTO
					{
						DesktopModuleID = moduleDefPair.Value.DesktopModuleID,
						ModuleID = moduleDefPair.Value.ModuleDefID,
						ModuleName = moduleDefPair.Value.FriendlyName,
						ModuleImage = GetDeskTopModuleImage(kvp.Value.DesktopModuleID),
						Bookmarked = bookmarkedModules.Any(m => m.Key == kvp.Key),
						ExistsInBookmarkCategory = bookmarkCategoryModules.Any(m => m.Key == kvp.Key)
					};

					modules.Add(moduleDefDTO);
				}
			}

			modules = modules.Skip(loadingStartIndex).Take(loadingPageSize).ToList();
			return Request.CreateResponse(HttpStatusCode.OK, modules);
		}
        
        [HttpGet]
        [DnnPageEditor]
        public HttpResponseMessage GetPageList(string portal)
        {
            var portalSettings = GetPortalSettings(portal);

            List<TabInfo> tabList = null;
            if (PortalSettings.PortalId == portalSettings.PortalId)
            {
                tabList = TabController.GetPortalTabs(portalSettings.PortalId, PortalSettings.ActiveTab.TabID, false, string.Empty, true, false, false, false, true);
            }
            else
            {
                var groups = PortalGroupController.Instance.GetPortalGroups().ToArray();

                var mygroup = (from @group in groups
                              select PortalGroupController.Instance.GetPortalsByGroup(@group.PortalGroupId)
                                  into portals
                                  where portals.Any(x => x.PortalID == PortalSettings.Current.PortalId)
                                  select portals.ToArray()).FirstOrDefault();

                if(mygroup != null && mygroup.Any(p=>p.PortalID == portalSettings.PortalId))
                {
                    tabList = TabController.GetPortalTabs(portalSettings.PortalId, Null.NullInteger, false, string.Empty, true, false, false, false, false);
                }
                else
                {
                    // try to get pages not allowed
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }

            List<PageDefDTO> result = new List<PageDefDTO>();
            foreach (var tab in tabList)
            {
                if (tab.PortalID == PortalSettings.PortalId || (GetModules(tab.TabID).Count > 0 && tab.TabID != portalSettings.AdminTabId && tab.ParentId != portalSettings.AdminTabId))
                {
                    result.Add(new PageDefDTO { TabID = tab.TabID, IndentedTabName = tab.IndentedTabName });
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [DnnPageEditor]
        public HttpResponseMessage GetTabModules(string tab)
        {
            int tabID;

            if (Int32.TryParse(tab, out tabID))
            {
                var result = new List<ModuleDefDTO>();
                if (tabID > 0)
                {
                    var pageModules = GetModules(tabID);

                    Dictionary<int, string> resultDict = pageModules.ToDictionary(module => module.ModuleID, module => module.ModuleTitle);
                    result.AddRange(from kvp in resultDict let imageUrl = GetTabModuleImage(tabID, kvp.Key) 
                                    select new ModuleDefDTO {ModuleID = kvp.Key, ModuleName = kvp.Value, ModuleImage = imageUrl}
                                    );
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }

            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        } 

        private IList<ModuleInfo> GetModules(int tabID)
        {
            var isRemote = TabController.Instance.GetTab(tabID, Null.NullInteger, false).PortalID != PortalSettings.Current.PortalId;
            var tabModules = ModuleController.Instance.GetTabModules(tabID);

            var pageModules = isRemote 
                                ? tabModules.Values.Where(m => ModuleSupportsSharing(m)).ToList() 
                                : tabModules.Values.Where(m => ModulePermissionController.CanAdminModule(m) && m.IsDeleted == false).ToList();

            return pageModules;

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [DnnPageEditor]
        public HttpResponseMessage CopyPermissionsToChildren()
        {
            if(TabPermissionController.CanManagePage() && UserController.Instance.GetCurrentUserInfo().IsInRole("Administrators")
                && ActiveTabHasChildren() && !PortalSettings.ActiveTab.IsSuperTab)
            {
                TabController.CopyPermissionsToChildren(PortalSettings.ActiveTab, PortalSettings.ActiveTab.TabPermissions);
                return Request.CreateResponse(HttpStatusCode.OK, new {Success= true});
            }

            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [DnnPageEditor]
        public HttpResponseMessage AddModule(AddModuleDTO dto)
        {
            if (TabPermissionController.CanAddContentToPage() && CanAddModuleToPage())
            {
                int permissionType;
                try
                {
                    permissionType = int.Parse(dto.Visibility);
                }
                catch (Exception exc)
                {
                    Logger.Error(exc);
                    permissionType = 0;
                }

                int positionID = -1;
                if (!string.IsNullOrEmpty(dto.Sort))
                {
                    int sortID = 0;
                    try
                    {
                        sortID = int.Parse(dto.Sort);
                        if(sortID >= 0)
                            positionID = GetPaneModuleOrder(dto.Pane, sortID);
                    }
                    catch(Exception exc)
                    {
                        Logger.Error(exc);
                    }
                }
                
                if(positionID == -1)
                {
                    switch (dto.Position)
                    {
                        case "TOP":
						case "0":
                            positionID = 0;
                            break;
                        case "BOTTOM":
						case "-1":
                            positionID = -1;
                            break;
                    }
                }

                int moduleLstID;
                try
                {
                    moduleLstID = int.Parse(dto.Module);
                }
                catch (Exception exc)
                {
                    Logger.Error(exc);
                    moduleLstID = -1;
                }

                try
                {
                    int tabModuleId = -1;
                    if ((moduleLstID > -1))
                    {
                        
                        if ((dto.AddExistingModule == "true"))
                        {
                            int pageID;
                            try
                            {
                                pageID = int.Parse(dto.Page);
                            }
                            catch (Exception exc)
                            {
                                Logger.Error(exc);
                                pageID = -1;
                            }

                            if ((pageID > -1))
                            {
                                tabModuleId = DoAddExistingModule(moduleLstID, pageID, dto.Pane, positionID, "", dto.CopyModule == "true");
                            }
                        }
                        else
                        {
                            tabModuleId = DoAddNewModule2("", moduleLstID, dto.Pane, positionID, permissionType, "");
                        }
                    }

                    return Request.CreateResponse(HttpStatusCode.OK, new { TabModuleID = tabModuleId});
                }
                catch(Exception ex)
                {
                    Logger.Error(ex);
                }                
            }

            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequireHost]
        public HttpResponseMessage ClearHostCache()
        {
            if (UserController.Instance.GetCurrentUserInfo().IsSuperUser)           
            {
                DataCache.ClearCache();
				ClientResourceManager.ClearCache();
                return Request.CreateResponse(HttpStatusCode.OK, new { Success = true });
            }

            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequireHost]
        public HttpResponseMessage RecycleApplicationPool()
        {
            if (UserController.Instance.GetCurrentUserInfo().IsSuperUser)
            {
                var log = new LogInfo { BypassBuffering = true, LogTypeKey = EventLogController.EventLogType.HOST_ALERT.ToString() };
                log.AddProperty("Message", "UserRestart");
                LogController.Instance.AddLog(log);
                Config.Touch();
                return Request.CreateResponse(HttpStatusCode.OK, new { Success = true });
            }

            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequireHost]
        public HttpResponseMessage SwitchSite(SwitchSiteDTO dto)
        {
            if (UserController.Instance.GetCurrentUserInfo().IsSuperUser)
            {
                try
                {
                    if ((!string.IsNullOrEmpty(dto.Site)))
                    {
                        int selectedPortalID = int.Parse(dto.Site);
                        var portalAliases = PortalAliasController.Instance.GetPortalAliasesByPortalId(selectedPortalID).ToList();

                        if ((portalAliases.Count > 0 && (portalAliases[0] != null)))
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, new { RedirectURL = Globals.AddHTTP(((PortalAliasInfo)portalAliases[0]).HTTPAlias) });
                        }
                    }
                }
                catch (System.Threading.ThreadAbortException)
                {
                    //Do nothing we are not logging ThreadAbortxceptions caused by redirects      
                }
                catch (Exception ex)
                {
                    Exceptions.LogException(ex);
                }
            }

            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public HttpResponseMessage SwitchLanguage(SwitchLanguageDTO dto)
        {
            if (UserController.Instance.GetCurrentUserInfo().IsSuperUser)
            {
                try
                {
                    if ((!string.IsNullOrEmpty(dto.Language)))
                    {
                        var personalizationController = new DotNetNuke.Services.Personalization.PersonalizationController();
                        var personalization = personalizationController.LoadProfile(UserInfo.UserID, PortalSettings.PortalId);
                        personalization.Profile["Usability:UICulture"] = dto.Language;
                        personalization.IsModified = true;
                        personalizationController.SaveProfile(personalization);
                        return Request.CreateResponse(HttpStatusCode.OK, new { Success = true });
                    }
                }
                catch (System.Threading.ThreadAbortException)
                {
                    //Do nothing we are not logging ThreadAbortxceptions caused by redirects      
                }
                catch (Exception ex)
                {
                    Exceptions.LogException(ex);
                }
            }

            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [DnnPageEditor]
        public HttpResponseMessage ToggleUserMode(UserModeDTO userMode)
        {
            if (userMode == null)
                userMode = new UserModeDTO { UserMode = "VIEW" };

            ToggleUserMode(userMode.UserMode);
            return Request.CreateResponse(HttpStatusCode.OK, new { Success = true });
        }

        public class BookmarkDTO
        {
            public string Title { get; set; }
            public string Bookmark { get; set; }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [DnnPageEditor]
        public HttpResponseMessage SaveBookmark(BookmarkDTO bookmark)
        {
            if (string.IsNullOrEmpty(bookmark.Bookmark)) bookmark.Bookmark = string.Empty;
            
            Controller.SaveBookMark(PortalSettings.PortalId, UserInfo.UserID, bookmark.Title, bookmark.Bookmark);

            return Request.CreateResponse(HttpStatusCode.OK, new { Success = true });
        }

        private void ToggleUserMode(string mode)
        {
            var personalizationController = new DotNetNuke.Services.Personalization.PersonalizationController();
            var personalization = personalizationController.LoadProfile(UserInfo.UserID, PortalSettings.PortalId);
            personalization.Profile["Usability:UserMode" + PortalSettings.PortalId] = mode.ToUpper();
            personalization.IsModified = true;
            personalizationController.SaveProfile(personalization);
        }

        private PortalSettings GetPortalSettings(string portal)
        {
            var portalSettings = PortalSettings.Current;

            try
            {

                if (!string.IsNullOrEmpty(portal))
                {
                    var selectedPortalId = int.Parse(portal);
                    if (PortalSettings.PortalId != selectedPortalId)
                    {
                        portalSettings = new PortalSettings(selectedPortalId);
                    }
                }

            }
            catch (Exception)
            {
                portalSettings = PortalSettings.Current;
            }

            return portalSettings;
        }

        private bool ModuleSupportsSharing(ModuleInfo moduleInfo)
        {
            switch (moduleInfo.DesktopModule.Shareable)
            {
                case ModuleSharing.Supported:
                case ModuleSharing.Unknown:
                    return moduleInfo.IsShareable;
                default:
                    return false;
            }
        }

        private string GetDeskTopModuleImage(int moduleId)
        {
            var portalDesktopModules = DesktopModuleController.GetDesktopModules(PortalSettings.Current.PortalId);
            var packages = PackageController.Instance.GetExtensionPackages(PortalSettings.Current.PortalId);

            string imageUrl =
                    (from pkgs in packages
                     join portMods in portalDesktopModules on pkgs.PackageID equals portMods.Value.PackageID
                     where portMods.Value.DesktopModuleID == moduleId
                     select pkgs.IconFile).FirstOrDefault();

            imageUrl = String.IsNullOrEmpty(imageUrl) ? Globals.ImagePath + DefaultExtensionImage : imageUrl;
            return System.Web.VirtualPathUtility.ToAbsolute(imageUrl);
        }

        private string GetTabModuleImage(int tabId, int moduleId)
        {
            var tabModules = ModuleController.Instance.GetTabModules(tabId);
            var portalDesktopModules = DesktopModuleController.GetDesktopModules(PortalSettings.Current.PortalId);
            var moduleDefnitions = ModuleDefinitionController.GetModuleDefinitions();
            var packages = PackageController.Instance.GetExtensionPackages(PortalSettings.Current.PortalId);

            string imageUrl = (from pkgs in packages
                               join portMods in portalDesktopModules on pkgs.PackageID equals portMods.Value.PackageID
                               join modDefs in moduleDefnitions on portMods.Value.DesktopModuleID equals modDefs.Value.DesktopModuleID
                               join tabMods in tabModules on modDefs.Value.DesktopModuleID equals tabMods.Value.DesktopModuleID
                               where tabMods.Value.ModuleID == moduleId
                               select pkgs.IconFile).FirstOrDefault();

            imageUrl = String.IsNullOrEmpty(imageUrl) ? Globals.ImagePath + DefaultExtensionImage : imageUrl; 
            return System.Web.VirtualPathUtility.ToAbsolute(imageUrl);
        }

        public bool CanAddModuleToPage()
        {
            return true;
            //If we are not in an edit page
            //return (string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["mid"])) && (string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["ctl"]));
        }

        private bool ActiveTabHasChildren()
        {
            var children = TabController.GetTabsByParent(PortalSettings.ActiveTab.TabID, PortalSettings.ActiveTab.PortalID);

            if (((children == null) || children.Count < 1))
            {
                return false;
            }

            return true;
        }

        private int DoAddExistingModule(int moduleId, int tabId, string paneName, int position, string align, bool cloneModule)
        {
            ModuleInfo moduleInfo = ModuleController.Instance.GetModule(moduleId, tabId, false);

            int userID = -1;
          
            UserInfo user = UserController.Instance.GetCurrentUserInfo();
            if (user != null)
            {
                userID = user.UserID;
            }
            

            if ((moduleInfo != null))
            {
                // Is this from a site other than our own? (i.e., is the user requesting "module sharing"?)
                var remote = moduleInfo.PortalID != PortalSettings.Current.PortalId;
                if (remote)
                {
                    switch (moduleInfo.DesktopModule.Shareable)
                    {
                        case ModuleSharing.Unsupported:
                            // Should never happen since the module should not be listed in the first place.
                            throw new ApplicationException(string.Format("Module '{0}' does not support Shareable and should not be listed in Add Existing Module from a different source site",
                                                                         moduleInfo.DesktopModule.FriendlyName));
                        case ModuleSharing.Supported:
                            break;
                        case ModuleSharing.Unknown:
                            break;
                    }
                }

                // clone the module object ( to avoid creating an object reference to the data cache )
                ModuleInfo newModule = moduleInfo.Clone();

                newModule.UniqueId = Guid.NewGuid(); // Cloned Module requires a different uniqueID

                newModule.TabID = PortalSettings.Current.ActiveTab.TabID;
                newModule.ModuleOrder = position;
                newModule.PaneName = paneName;
                newModule.Alignment = align;

                if ((cloneModule))
                {
                    newModule.ModuleID = Null.NullInteger;
                    //reset the module id
                    newModule.ModuleID = ModuleController.Instance.AddModule(newModule);

                    if (!string.IsNullOrEmpty(newModule.DesktopModule.BusinessControllerClass))
                    {
                        object objObject = DotNetNuke.Framework.Reflection.CreateObject(newModule.DesktopModule.BusinessControllerClass, newModule.DesktopModule.BusinessControllerClass);
                        if (objObject is IPortable)
                        {
                            string content = Convert.ToString(((IPortable)objObject).ExportModule(moduleId));
                            if (!string.IsNullOrEmpty(content))
                            {
                                ((IPortable)objObject).ImportModule(newModule.ModuleID, content, newModule.DesktopModule.Version, userID);
                            }
                        }
                    }
                }
                else
                {
                    ModuleController.Instance.AddModule(newModule);
                }

                //if the tab of original module has custom stylesheet defined, then also copy the stylesheet
                //to the destination tab if its custom stylesheet is empty.
                var originalTab = TabController.Instance.GetTab(moduleInfo.TabID, moduleInfo.PortalID);
                var targetTab = PortalSettings.Current.ActiveTab;
                if (originalTab != null
                    && originalTab.TabSettings.ContainsKey("CustomStylesheet")
                    && !string.IsNullOrEmpty(originalTab.TabSettings["CustomStylesheet"].ToString())
                    && (!targetTab.TabSettings.ContainsKey("CustomStylesheet") ||
                            string.IsNullOrEmpty(targetTab.TabSettings["CustomStylesheet"].ToString())))
                {
                    TabController.Instance.UpdateTabSetting(targetTab.TabID, "CustomStylesheet", originalTab.TabSettings["CustomStylesheet"].ToString());
                }

                if (remote)
                {
                    //Ensure the Portal Admin has View rights
                    var permissionController = new PermissionController();
                    ArrayList arrSystemModuleViewPermissions = permissionController.GetPermissionByCodeAndKey("SYSTEM_MODULE_DEFINITION", "VIEW");
                    AddModulePermission(newModule,
                                    (PermissionInfo)arrSystemModuleViewPermissions[0],
                                    PortalSettings.Current.AdministratorRoleId,
                                    Null.NullInteger,
                                    true);

                    //Set PortalID correctly
                    newModule.OwnerPortalID = newModule.PortalID;
                    newModule.PortalID = PortalSettings.Current.PortalId;
                    ModulePermissionController.SaveModulePermissions(newModule);
                }

                //Add Event Log
                EventLogController.Instance.AddLog(newModule, PortalSettings.Current, userID, "", EventLogController.EventLogType.MODULE_CREATED);

                return newModule.ModuleID;
            }

            return -1;
        }

        private ModulePermissionInfo AddModulePermission(ModuleInfo objModule, PermissionInfo permission, int roleId, int userId, bool allowAccess)
        {
            var objModulePermission = new ModulePermissionInfo
            {
                ModuleID = objModule.ModuleID,
                PermissionID = permission.PermissionID,
                RoleID = roleId,
                UserID = userId,
                PermissionKey = permission.PermissionKey,
                AllowAccess = allowAccess
            };

            // add the permission to the collection
            if (!objModule.ModulePermissions.Contains(objModulePermission))
            {
                objModule.ModulePermissions.Add(objModulePermission);
            }

            return objModulePermission;
        }

        private int GetPaneModuleOrder(string pane, int sort)
        {
            var items = new List<int>();

            foreach (ModuleInfo m in PortalSettings.Current.ActiveTab.Modules)
            {
                //if user is allowed to view module and module is not deleted
                if (ModulePermissionController.CanViewModule(m) && !m.IsDeleted)
                {
                    //modules which are displayed on all tabs should not be displayed on the Admin or Super tabs
                    if (!m.AllTabs || !PortalSettings.Current.ActiveTab.IsSuperTab)
                    {
                        if (string.Equals(m.PaneName, pane, StringComparison.OrdinalIgnoreCase))
                        {
                            int moduleOrder = m.ModuleOrder;

                            while (items.Contains(moduleOrder) || moduleOrder == 0)
                            {
                                moduleOrder++;
                            }

                            items.Add(moduleOrder);
                        }
                    }
                }
            }

            items.Sort();

            if(items.Count > sort)
            {
                var itemOrder = items[sort];
                return itemOrder - 1;
            }
            else if(items.Count > 0)
            {
                return items.Last() + 1;
            }

            return 0;
        }

		private int DoAddNewModule2(string title, int moduleDefinitionId, string paneName, int position, int permissionType, string align)
		{
			ModuleDefinitionInfo objModuleDefinition = ModuleDefinitionController.GetModuleDefinitionByID(moduleDefinitionId);

			var tabModuleId = Null.NullInteger;
			
			var objModule = new ModuleInfo();
			objModule.Initialize(PortalSettings.Current.ActiveTab.PortalID);

			objModule.PortalID = PortalSettings.Current.ActiveTab.PortalID;
			objModule.TabID = PortalSettings.Current.ActiveTab.TabID;
			objModule.ModuleOrder = position;
			objModule.ModuleTitle = string.IsNullOrEmpty(title) ? objModuleDefinition.FriendlyName : title;
			objModule.PaneName = paneName;
			objModule.ModuleDefID = objModuleDefinition.ModuleDefID;
			if (objModuleDefinition.DefaultCacheTime > 0)
			{
				objModule.CacheTime = objModuleDefinition.DefaultCacheTime;
				if (PortalSettings.Current.DefaultModuleId > Null.NullInteger && PortalSettings.Current.DefaultTabId > Null.NullInteger)
				{
					ModuleInfo defaultModule = ModuleController.Instance.GetModule(PortalSettings.Current.DefaultModuleId, PortalSettings.Current.DefaultTabId, true);
					if ((defaultModule != null))
					{
						objModule.CacheTime = defaultModule.CacheTime;
					}
				}
			}

			ModuleController.Instance.InitialModulePermission(objModule, objModule.TabID, permissionType);

			if (PortalSettings.Current.ContentLocalizationEnabled)
			{
				Locale defaultLocale = LocaleController.Instance.GetDefaultLocale(PortalSettings.Current.PortalId);
				//set the culture of the module to that of the tab
				var tabInfo = TabController.Instance.GetTab(objModule.TabID, PortalSettings.Current.PortalId, false);
				objModule.CultureCode = tabInfo != null ? tabInfo.CultureCode : defaultLocale.Code;
			}
			else
			{
				objModule.CultureCode = Null.NullString;
			}
			objModule.AllTabs = false;
			objModule.Alignment = align;

			ModuleController.Instance.AddModule(objModule);

			if (tabModuleId == Null.NullInteger)
			{
				tabModuleId = objModule.ModuleID;
			}
			//update the position to let later modules with add after previous one.
			position = ModuleController.Instance.GetTabModule(objModule.TabModuleID).ModuleOrder + 1;

			return tabModuleId;
		}

        private int DoAddNewModule(string title, int desktopModuleId, string paneName, int position, int permissionType, string align)
        {
            try
            {
                DesktopModuleInfo desktopModule;
                if (!DesktopModuleController.GetDesktopModules(PortalSettings.Current.PortalId).TryGetValue(desktopModuleId, out desktopModule))
                {
                    throw new ArgumentException("desktopModuleId");
                }
            }
            catch (Exception ex)
            {
                Exceptions.LogException(ex);
            }

	        var tabModuleId = Null.NullInteger;
            foreach (ModuleDefinitionInfo objModuleDefinition in
                ModuleDefinitionController.GetModuleDefinitionsByDesktopModuleID(desktopModuleId).Values)
            {
                var objModule = new ModuleInfo();
                objModule.Initialize(PortalSettings.Current.ActiveTab.PortalID);

                objModule.PortalID = PortalSettings.Current.ActiveTab.PortalID;
                objModule.TabID = PortalSettings.Current.ActiveTab.TabID;
                objModule.ModuleOrder = position;
                objModule.ModuleTitle = string.IsNullOrEmpty(title) ? objModuleDefinition.FriendlyName : title;
                objModule.PaneName = paneName;
                objModule.ModuleDefID = objModuleDefinition.ModuleDefID;
                if (objModuleDefinition.DefaultCacheTime > 0)
                {
                    objModule.CacheTime = objModuleDefinition.DefaultCacheTime;
                    if (PortalSettings.Current.DefaultModuleId > Null.NullInteger && PortalSettings.Current.DefaultTabId > Null.NullInteger)
                    {
                        ModuleInfo defaultModule = ModuleController.Instance.GetModule(PortalSettings.Current.DefaultModuleId, PortalSettings.Current.DefaultTabId, true);
                        if ((defaultModule != null))
                        {
                            objModule.CacheTime = defaultModule.CacheTime;
                        }
                    }
                }

                ModuleController.Instance.InitialModulePermission(objModule, objModule.TabID, permissionType);

                if (PortalSettings.Current.ContentLocalizationEnabled)
                {
                    Locale defaultLocale = LocaleController.Instance.GetDefaultLocale(PortalSettings.Current.PortalId);
                    //set the culture of the module to that of the tab
                    var tabInfo = TabController.Instance.GetTab(objModule.TabID, PortalSettings.Current.PortalId, false);
                    objModule.CultureCode = tabInfo != null ? tabInfo.CultureCode : defaultLocale.Code;
                }
                else
                {
                    objModule.CultureCode = Null.NullString;
                }
                objModule.AllTabs = false;
                objModule.Alignment = align;

                ModuleController.Instance.AddModule(objModule);

				if (tabModuleId == Null.NullInteger)
				{
					tabModuleId = objModule.ModuleID;
				}
				//update the position to let later modules with add after previous one.
                position = ModuleController.Instance.GetTabModule(objModule.TabModuleID).ModuleOrder + 1;
            }

			return tabModuleId;
        }

		private string GetModuleName(string moduleName)
		{
			 if (_nameDics == null)
			 {
				 _nameDics = new Dictionary<string, string> {{"SearchCrawlerAdmin", "SearchCrawler Admin"}, 
															 {"SearchCrawlerInput", "SearchCrawler Input"}, 
															 {"SearchCrawlerResults", "SearchCrawler Results"}};
			 }

			return _nameDics.ContainsKey(moduleName) ? _nameDics[moduleName] : moduleName;
		}
    }
}