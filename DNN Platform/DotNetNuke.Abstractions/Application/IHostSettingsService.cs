﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information
namespace DotNetNuke.Abstractions.Application
{
    using DotNetNuke.Abstractions.Settings;

    /// <summary>
    /// The <see cref="IHostSettingsService"/> provides business layer of the HostSettings
    /// Entity.
    /// </summary>
    /// <example>
    /// 
    /// <code lang="C#">
    /// public class MySampleClass
    /// {
    ///     IHostSettingsService service;
    ///     public MySampleClass(IHostSettingsService service)
    ///     {
    ///         this.service = service;
    ///     }
    ///
    ///     public bool CheckUpgrade { get => this.service.GetBoolean("CheckUpgrade", true);
    /// }
    /// </code>
    /// </example>
    public interface IHostSettingsService : ISettingsService { }
}
