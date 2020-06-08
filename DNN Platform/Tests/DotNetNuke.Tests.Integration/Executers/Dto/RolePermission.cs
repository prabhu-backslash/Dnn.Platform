﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information
using System.Collections.Generic;

namespace DotNetNuke.Tests.Integration.Executers.Dto
{
    public class RolePermission
    {
        public int RoleId { get; set; }
        
        public string RoleName { get; set; }
        
        public IList<Permission> Permissions { get; set; }
        
        public bool Locked { get; set; }
        
        public bool IsDefault { get; set; }
    }
}
