﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information

namespace DotNetNuke.Abstractions.Prompt
{
    using System;

    /// <summary>
    /// This is used in the ICommandHelp to send a list of command parameters to the client for explanatory help.
    /// </summary>
    [Obsolete("Deprecated in favor of IDnnCommandOption. Will be removed in a future release.", false)]
    public interface ICommandOption : IDnnCommandOption
    {
    }
}
