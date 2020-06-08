﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information
using System;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Tests.Utilities;

namespace DotNetNuke.Tests.Data.Models
{
    [Scope(Constants.CACHE_ScopeModule)]
    public class Cat
    {
        public int? Age { get; set; }
        public int ModuleId { get; set; }
        public string Name { get; set; }
    }
}
