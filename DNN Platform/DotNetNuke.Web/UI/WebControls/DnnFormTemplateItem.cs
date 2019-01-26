﻿#region Copyright
// 
// DNN® and DotNetNuke® - http://www.DNNSoftware.com
// Copyright ©2002-2019
// by DNN Corp
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
#region Usings

using System.ComponentModel;
using System.Web.UI;

#endregion

namespace DotNetNuke.Web.UI.WebControls
{
    [ParseChildren(true)]
    public class DnnFormTemplateItem : DnnFormItemBase
    {
        [Browsable(false), DefaultValue(null), Description("The Item Template."), TemplateInstance(TemplateInstance.Single), PersistenceMode(PersistenceMode.InnerProperty),
         TemplateContainer(typeof (DnnFormEmptyTemplate))]
        public ITemplate ItemTemplate { get; set; }

        protected override void CreateControlHierarchy()
        {
            CssClass += " dnnFormItem";
            CssClass += (FormMode == DnnFormMode.Long) ? " dnnFormLong" : " dnnFormShort";

            var template = new DnnFormEmptyTemplate();
            ItemTemplate.InstantiateIn(template);
            Controls.Add(template);
        }
    }
}