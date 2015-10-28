#region Copyright
// 
// DotNetNukeŽ - http://www.dotnetnuke.com
// Copyright (c) 2002-2015
// by DotNetNuke Corporation
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
// to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or substantial portions 
// of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
// TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE.
#endregion

using System;
using System.Collections;
using System.Diagnostics;
using System.Web.UI.HtmlControls;

namespace DotNetNuke.UI.Utilities
{
	//do not want this control for dnnVariable to ever use a naming container
	//somewhat of a hack here...
	public class NonNamingHiddenInput : HtmlInputHidden
	{

		private bool m_ValueSet = false;
		public override string Value {
			get {
				if (!string.IsNullOrEmpty(this.Page.Request.Form[this.ID]) && m_ValueSet == false) {
					return this.Page.Request.Form[this.ID];
				}
				return base.Value;
			}
			set {
				m_ValueSet = true;
				base.Value = value;
			}
		}
		public override System.Web.UI.Control NamingContainer {
			get { return null; }
		}
	}
}
