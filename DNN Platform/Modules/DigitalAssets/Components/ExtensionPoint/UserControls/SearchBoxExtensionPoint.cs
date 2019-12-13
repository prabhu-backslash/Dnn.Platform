﻿using System;
using System.ComponentModel.Composition;

using DotNetNuke.ExtensionPoints;

namespace DotNetNuke.Modules.DigitalAssets.Components.ExtensionPoint.UserControls
{
    [Export(typeof(IUserControlExtensionPoint))]
    [ExportMetadata("Module", "DigitalAssets")]
    [ExportMetadata("Name", "SearchBoxExtensionPoint")]
    [ExportMetadata("Group", "View")]
    [ExportMetadata("Priority", 2)]
    public class SearchBoxExtensionPoint : IUserControlExtensionPoint
    {
        public string UserControlSrc
        {
            get { return "~/DesktopModules/DigitalAssets/SearchBoxControl.ascx"; }
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
