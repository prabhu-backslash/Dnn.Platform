﻿// 
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// 
#region Usings

using System;

using Telerik.Web.UI;

#endregion

namespace DotNetNuke.Web.UI.WebControls
{
    public class DnnPanelBar : RadPanelBar
    {

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Utilities.ApplySkin(this);
        }

    }
}
