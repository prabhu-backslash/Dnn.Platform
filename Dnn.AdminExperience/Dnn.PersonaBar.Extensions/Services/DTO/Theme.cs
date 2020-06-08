﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information
using System.Runtime.Serialization;

namespace Dnn.PersonaBar.Pages.Services.Dto
{
    [DataContract]
    public class Theme
    {
        [DataMember(Name = "skinSrc")]
        public string SkinSrc { get; set; }

        [DataMember(Name = "containerSrc")]
        public string ContainerSrc { get; set; }
    }
}
