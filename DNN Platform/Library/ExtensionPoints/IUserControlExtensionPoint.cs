﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information

namespace DotNetNuke.ExtensionPoints
{
    using System;

    public interface IUserControlExtensionPoint : IExtensionPoint
    {
        string UserControlSrc { get; }

        bool Visible { get; }
    }
}
