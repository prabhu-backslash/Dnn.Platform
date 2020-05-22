﻿// 
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// 
using DotNetNuke.Abstractions.Portals;
using DotNetNuke.Abstractions.Prompt;
using DotNetNuke.Abstractions.Users;
using DotNetNuke.Collections;
using DotNetNuke.Services.Cache;
using DotNetNuke.Services.Localization;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Caching;

namespace DotNetNuke.Prompt
{
    public abstract class ConsoleCommandBase : IConsoleCommand
    {
        public abstract string LocalResourceFile { get; }
        protected IPortalSettings PortalSettings { get; private set; }
        protected IUserInfo User { get; private set; }
        protected int PortalId { get; private set; }
        protected int TabId { get; private set; }
        protected string[] Args { get; private set; }
        protected IDictionary<string, string> Flags { get; private set; }
        private IList<ParameterMapping> Mapping { get; }

        #region Protected Methods
        protected string LocalizeString(string key)
        {
            var localizedText = Localization.GetString(key, LocalResourceFile);
            return string.IsNullOrEmpty(localizedText) ? key : localizedText;
        }
        protected void AddMessage(string message)
        {
            ValidationMessage += message;
        }
        protected void ParseParameters<T>(T myCommand) where T : class, new()
        {
            Mapping.ForEach(mapping =>
            {
                var attribute = mapping.Attribute;
                var property = mapping.Property;
                var settingValue = Flags.ContainsKey(attribute.Name) ? Flags[attribute.Name] : null;
                if (settingValue != null && property.CanWrite)
                {
                    var tp = property.PropertyType;
                    Entities.Modules.Settings.SerializationController.DeserializeProperty(myCommand, property, settingValue);
                }
            });
        }
        #endregion

        #region Public Methods
        public virtual void Initialize(string[] args, IPortalSettings portalSettings, IUserInfo userInfo, int activeTabId)
        {
            Args = args;
            PortalSettings = portalSettings;
            User = userInfo;
            PortalId = portalSettings.PortalId;
            TabId = activeTabId;
            ValidationMessage = "";
            ParseFlags();
        }

        public abstract IConsoleResultModel Run();

        public virtual bool IsValid()
        {
            return string.IsNullOrEmpty(ValidationMessage);
        }       
        #endregion

        #region Private Methods
        private void ParseFlags()
        {
            Flags = new Dictionary<string, string>();
            // loop through arguments, skipping the first one (the command)
            for (var i = 1; i <= Args.Length - 1; i++)
            {
                if (!Args[i].StartsWith("--")) continue;
                // found a flag
                var flagName = NormalizeFlagName(Args[i]);
                var flagValue = string.Empty;
                if (i < Args.Length - 1)
                {
                    if (!string.IsNullOrEmpty(Args[i + 1]))
                    {
                        if (Args[i + 1].StartsWith("--"))
                        {
                            // next value is another flag, so this flag has no value
                            flagValue = string.Empty;
                        }
                        else
                        {
                            flagValue = Args[i + 1];
                        }
                    }
                    else
                    {
                        flagValue = string.Empty;
                    }
                }
                Flags.Add(flagName.ToLower(), flagValue);
            }
        }
        #endregion

        #region Helper Methods
        private static string NormalizeFlagName(string flagName)
        {
            if (flagName == null)
                return string.Empty;
            if (flagName.StartsWith("--"))
                flagName = flagName.Substring(2);
            return flagName.ToLower().Trim();
        }
        #endregion

        public string ValidationMessage { get; private set; }

        /// <summary>
        /// Resource key for the result html.
        /// </summary>
        public virtual string ResultHtml => LocalizeString($"Prompt_{GetType().Name}_ResultHtml");

        #region Mapping Properties
        public struct ParameterMapping
        {
            public ConsoleCommandParameterAttribute Attribute { get; set; }
            public PropertyInfo Property { get; set; }
        }
        protected IList<ParameterMapping> LoadMapping()
        {
            var cacheKey = MappingCacheKey;
            var mapping = CachingProvider.Instance().GetItem(cacheKey) as IList<ParameterMapping>;
            if (mapping == null)
            {
                mapping = CreateMapping();
                // HARDCODED: 2 hour expiration. 
                // Note that "caching" can also be accomplished with a static dictionary since the Attribute/Property mapping does not change unless the module is updated.
                CachingProvider.Instance().Insert(cacheKey, mapping, null, DateTime.Now.AddHours(2), Cache.NoSlidingExpiration);
            }

            return mapping;
        }

        public const string CachePrefix = "ConsoleCommandPersister_";
        protected virtual string MappingCacheKey
        {
            get
            {
                var type = GetType();
                return CachePrefix + type.FullName.Replace(".", "_");
            }
        }

        protected virtual IList<ParameterMapping> CreateMapping()
        {
            var mapping = new List<ParameterMapping>();
            var type = GetType();
            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.SetProperty);

            properties.ForEach(property =>
            {
                var attributes = property.GetCustomAttributes<ConsoleCommandParameterAttribute>(true);
                attributes.ForEach(attribute => mapping.Add(new ParameterMapping() { Attribute = attribute, Property = property }));
            });

            return mapping;
        }
        #endregion
    }
}
