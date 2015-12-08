﻿// Copyright (c) DNN Software. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace DotNetNuke.Web.Mvc.Helpers
{
    /// <summary>
    /// Provides a mechanism to get display names.
    /// </summary>
    public static class HtmlDisplayNameExtensions
    {
        /// <summary>
        /// Gets the display name.
        /// </summary>
        /// 
        /// <returns>
        /// The display name.
        /// </returns>
        /// <param name="html">The HTML helper instance that this method extends.</param><param name="expression">An expression that identifies the object that contains the display name.</param>
        public static MvcHtmlString DisplayName(this DnnHtmlHelper html, string expression)
        {
            return html.HtmlHelper.DisplayName(expression);
        }

        /// <summary>
        /// Gets the display name for the model.
        /// </summary>
        /// 
        /// <returns>
        /// The display name for the model.
        /// </returns>
        /// <param name="html">The HTML helper instance that this method extends.</param><param name="expression">An expression that identifies the object that contains the display name.</param><typeparam name="TModel">The type of the model.</typeparam><typeparam name="TValue">The type of the value.</typeparam>
        public static MvcHtmlString DisplayNameFor<TModel, TValue>(this DnnHtmlHelper<IEnumerable<TModel>> html, Expression<Func<TModel, TValue>> expression)
        {
            return html.HtmlHelper.DisplayNameFor(expression);
        }

        /// <summary>
        /// Gets the display name for the model.
        /// </summary>
        /// 
        /// <returns>
        /// The display name for the model.
        /// </returns>
        /// <param name="html">The HTML helper instance that this method extends.</param><param name="expression">An expression that identifies the object that contains the display name.</param><typeparam name="TModel">The type of the model.</typeparam><typeparam name="TValue">The type of the value.</typeparam>
        public static MvcHtmlString DisplayNameFor<TModel, TValue>(this DnnHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            return html.HtmlHelper.DisplayNameFor(expression);
        }

        /// <summary>
        /// Gets the display name for the model.
        /// </summary>
        /// 
        /// <returns>
        /// The display name for the model.
        /// </returns>
        /// <param name="html">The HTML helper instance that this method extends.</param>
        public static MvcHtmlString DisplayNameForModel(this DnnHtmlHelper html)
        {
            return html.HtmlHelper.DisplayNameForModel();
        }
    }
}
