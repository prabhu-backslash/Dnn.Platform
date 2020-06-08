﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetNuke.UI.UserControls
{
    public interface IFilePickerUploader
    {
        int FileID { get; set; }

        string FilePath { get; set; }

        string FileFilter { get; set; }
    }
}
