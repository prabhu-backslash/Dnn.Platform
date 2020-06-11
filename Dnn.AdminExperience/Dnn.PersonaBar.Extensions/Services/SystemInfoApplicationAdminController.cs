﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information

using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dnn.PersonaBar.Library;
using Dnn.PersonaBar.Library.Attributes;
using DotNetNuke.Application;
using DotNetNuke.Framework;
using DotNetNuke.Framework.Providers;
using DotNetNuke.Instrumentation;


namespace Dnn.PersonaBar.Servers.Services
{
    [MenuPermission(Scope = ServiceScope.Admin)]
    public class SystemInfoApplicationAdminController : PersonaBarApiController
    {
        private static readonly ILog Logger = LoggerSource.Instance.GetLogger(typeof(SystemInfoApplicationAdminController));

        [HttpGet]
        public HttpResponseMessage GetApplicationInfo()
        {
            try
            {
                var friendlyUrlProvider = this.GetProviderConfiguration("friendlyUrl");
                return this.Request.CreateResponse(HttpStatusCode.OK, new
                {
                    product = DotNetNukeContext.Current.Application.Description,
                    version = DotNetNukeContext.Current.Application.Version.ToString(3),
                    htmlEditorProvider = this.GetProviderConfiguration("htmlEditor"),
                    dataProvider = this.GetProviderConfiguration("data"),
                    cachingProvider = this.GetProviderConfiguration("caching"),
                    loggingProvider = this.GetProviderConfiguration("logging"),
                    friendlyUrlProvider,
                    friendlyUrlsEnabled = DotNetNuke.Entities.Host.Host.UseFriendlyUrls.ToString(),
                    friendlyUrlType = GetFriendlyUrlType(friendlyUrlProvider),
                    schedulerMode = DotNetNuke.Entities.Host.Host.SchedulerMode.ToString(),
                    webFarmEnabled = DotNetNuke.Services.Cache.CachingProvider.Instance().IsWebFarm().ToString(),
                    casPermissions = SecurityPolicy.Permissions
                });
            }
            catch (Exception exc)
            {
                Logger.Error(exc);
                return this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc);
            }
        }

        private string GetProviderConfiguration(string providerName)
        {
            return ProviderConfiguration.GetProviderConfiguration(providerName).DefaultProvider;
        }

        private static string GetFriendlyUrlType(string friendlyUrlProvider)
        {
            var urlProvider = (Provider)ProviderConfiguration.GetProviderConfiguration("friendlyUrl").Providers[friendlyUrlProvider];
            var urlFormat = urlProvider.Attributes["urlformat"];
            return string.IsNullOrWhiteSpace(urlFormat) ? "SearchFriendly" : FirstCharToUpper(urlFormat);
        }

        public static string FirstCharToUpper(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }
            return input.First().ToString().ToUpper() + string.Join("", input.Skip(1));
        }
    }
}
