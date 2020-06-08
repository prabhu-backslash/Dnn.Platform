﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information
using System;
using System.ComponentModel.Composition;

using DotNetNuke.ExtensionPoints;

namespace DotNetNuke.Modules.DigitalAssets.Components.ExtensionPoint.UserControls
{
    [Export(typeof(IUserControlExtensionPoint))]
    [ExportMetadata("Module", "DigitalAssets")]
    [ExportMetadata("Name", "PreviewInfoPanelExtensionPoint")]
    [ExportMetadata("Group", "ViewProperties")]
    [ExportMetadata("Priority", 2)]
    public class PreviewInfoPanelExtensionPoint : IUserControlExtensionPoint
    {
        public string UserControlSrc
        {
            get { return "~/DesktopModules/DigitalAssets/PreviewPanelControl.ascx"; }
        }

        public string Text
        {
            get { return ""; }
        }

        public string Icon
        {
            get { return ""; }
        }

        public int Order
        {
            get { return 1; }
        }

        public bool Visible
        {
            get { return true; }
        }
    }
}
