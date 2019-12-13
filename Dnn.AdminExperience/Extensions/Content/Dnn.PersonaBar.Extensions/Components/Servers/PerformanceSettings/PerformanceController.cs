﻿// 
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// 
using System.Collections.Generic;
using System.Linq;
using DotNetNuke.Framework.Providers;
using DotNetNuke.Services.ModuleCache;
using DotNetNuke.Services.OutputCache;

namespace Dnn.PersonaBar.Servers.Components.PerformanceSettings
{
    public class PerformanceController
    {
        public object GetPageStatePersistenceOptions()
        {
            return new[]
            {
                new KeyValuePair<string, string>("Page", "P"),
                new KeyValuePair<string, string>("Memory", "M")
            };
        }

        public IEnumerable<KeyValuePair<string, string>> GetModuleCacheProviders()
        {
            return GetFilteredProviders(ModuleCachingProvider.GetProviderList(), "ModuleCachingProvider");
        }

        public IEnumerable<KeyValuePair<string, string>> GetPageCacheProviders()
        {
            return GetFilteredProviders(OutputCachingProvider.GetProviderList(), "OutputCachingProvider");
        }

        public IEnumerable<KeyValuePair<string, string>> GetCachingProviderOptions()
        {
            var providers = ProviderConfiguration.GetProviderConfiguration("caching").Providers;

            return (from object key in providers.Keys select new KeyValuePair<string, string>((string) key, (string) key)).ToList();
        }

        public object GetCacheSettingOptions()
        {
            return new []
            {
                new KeyValuePair<string, int>("NoCaching", 0),
                new KeyValuePair<string, int>("LightCaching", 1),
                new KeyValuePair<string, int>("ModerateCaching", 3),
                new KeyValuePair<string, int>("HeavyCaching", 6)
            };
        }

        public object GetCacheabilityOptions()
        {
            return new []
            {
                new KeyValuePair<string, string>("NoCache", "0"),
                new KeyValuePair<string, string>("Private", "1"),
                new KeyValuePair<string, string>("Public", "2"),
                new KeyValuePair<string, string>("Server", "3"),
                new KeyValuePair<string, string>("ServerAndNoCache", "4"),
                new KeyValuePair<string, string>("ServerAndPrivate", "5")
            };
        }

        private IEnumerable<KeyValuePair<string, string>> GetFilteredProviders<T>(Dictionary<string, T> providerList, string keyFilter)
        {
            var providers = from provider in providerList let filteredkey = provider.Key.Replace(keyFilter, string.Empty) select new KeyValuePair<string, string> (filteredkey, provider.Key);
            return providers;
        }

        public string GetCachingProvider()
        {
            return ProviderConfiguration.GetProviderConfiguration("caching").DefaultProvider;
        }
    }
}
