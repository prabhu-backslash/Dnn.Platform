﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information
#region Usings

using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using DotNetNuke.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

#endregion

namespace Dnn.PersonaBar.TaskScheduler.Services.Dto
{
    public class UpdateSettingsRequest
    {
        public string SchedulerMode { get; set; }

        public string SchedulerdelayAtAppStart { get; set; }
    }
}
