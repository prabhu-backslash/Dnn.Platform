﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information

#region Usings

using System;

using DotNetNuke.Application;
using DotNetNuke.Entities.Host;

#endregion

namespace DotNetNuke.UI.Skins.Controls
{
    /// -----------------------------------------------------------------------------
    /// <summary></summary>
    /// <remarks></remarks>
    /// -----------------------------------------------------------------------------
    public partial class DotNetNukeControl : SkinObjectBase
    {
        public string CssClass { get; set; }

        private void InitializeComponent()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            this.InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!String.IsNullOrEmpty(this.CssClass))
            {
                this.hypDotNetNuke.CssClass = this.CssClass;
            }
			
            //get Product Name and Legal Copyright from constants (Medium Trust)
            this.hypDotNetNuke.Text = DotNetNukeContext.Current.Application.LegalCopyright;
            this.hypDotNetNuke.NavigateUrl = DotNetNukeContext.Current.Application.Url;
            
			//show copyright credits?
			this.Visible = Host.DisplayCopyright;
        }
    }
}
