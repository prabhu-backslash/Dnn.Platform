﻿// 
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// 
using System;

namespace DotNetNuke.Entities.Users
{
    public class UpdateUserEventArgs : UserEventArgs
    {
        public UserInfo OldUser { get; set; }
    }
}
