﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information
using System;
using System.Collections.Generic;
using System.IO;

namespace DotNetNuke.Entities.Portals.Internal
{
    public interface IPortalTemplateIO
    {
        IEnumerable<string> EnumerateTemplates();
        IEnumerable<string> EnumerateLanguageFiles();
        string GetResourceFilePath(string templateFilePath);
        string GetLanguageFilePath(string templateFilePath, string cultureCode);
        TextReader OpenTextReader(string filePath);
    }
}
