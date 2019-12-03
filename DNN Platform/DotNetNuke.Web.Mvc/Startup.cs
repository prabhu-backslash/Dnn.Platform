﻿using DotNetNuke.Common;
using DotNetNuke.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Web.Mvc;

namespace DotNetNuke.Web.Mvc
{
    public class Startup : IDnnStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(serviceProvider => ControllerBuilder.Current.GetControllerFactory());
            services.AddSingleton<MvcModuleControlFactory>();

            IDependencyResolver resolver = new DnnMvcDependencyResolver(Globals.DependencyProvider, DependencyResolver.Current);
            DependencyResolver.SetResolver(resolver);
        }
    }
}
