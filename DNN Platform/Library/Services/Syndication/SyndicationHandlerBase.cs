﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information
#region Usings

using System;
using System.Web;

using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Portals;

#endregion

namespace DotNetNuke.Services.Syndication
{
    public class SyndicationHandlerBase : GenericRssHttpHandlerBase
    {
        private int _moduleId = Null.NullInteger;

        private int _tabId = Null.NullInteger;

        public PortalSettings Settings
        {
            get
            {
                return Globals.GetPortalSettings();
            }
        }

        public int TabId
        {
            get
            {
                if (_tabId == Null.NullInteger && Request.QueryString["tabid"] != null)
                {
                    if (! Int32.TryParse(Request.QueryString["tabid"], out _tabId))
                    {
                        _tabId = Null.NullInteger;
                    }
                }
                return _tabId;
            }
        }

        public int ModuleId
        {
            get
            {
                if (_moduleId == Null.NullInteger && Request.QueryString["moduleid"] != null)
                {
                    if (! Int32.TryParse(Request.QueryString["moduleid"], out _moduleId))
                    {
                        _moduleId = Null.NullInteger;
                    }
                }
                return _moduleId;
            }
        }

        public HttpRequest Request
        {
            get
            {
                return HttpContext.Current.Request;
            }
        }
    }
}
