﻿
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using DotNetNuke.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Dnn.PersonaBar.Security.Services.Dto
{
    public class UpdateIpFilterRequest
    {
        public string IPAddress { get; set; }

        public string SubnetMask { get; set; }

        public int RuleType { get; set; }

        public int IPFilterID { get; set; }
    }
}
