#region Copyright
//
// DotNetNuke® - https://www.dnnsoftware.com
// Copyright (c) 2002-2018
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
#region Usings

using System;
using System.Reflection;
using System.Runtime.CompilerServices;

using DotNetNuke.Application;
#endregion

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.

// Review the values of the assembly attributes

[assembly: AssemblyTitle("DotNetNuke")]
[assembly: AssemblyDescription("Open Source Web Application Framework")]
[assembly: CLSCompliant(true)]

[assembly: AssemblyStatus(ReleaseMode.Alpha)]

// Allow internal variables to be visible to testing projects
[assembly: InternalsVisibleTo("DotNetNuke.Tests.Core")]

// This assembly is the default dynamic assembly generated Castle DynamicProxy,
// used by Moq. Paste in a single line.
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("DotNetNuke.Web")]
[assembly: InternalsVisibleTo("DotNetNuke.Web.Mvc")]
[assembly: InternalsVisibleTo("DotNetNuke.Web.Razor")]
[assembly: InternalsVisibleTo("DotNetNuke.HttpModules")]
[assembly: InternalsVisibleTo("DotNetNuke.Modules.MemberDirectory")]
[assembly: InternalsVisibleTo("DotNetNuke.Provider.AspNetProvider")]
[assembly: InternalsVisibleTo("DotNetNuke.Tests.Content")]
[assembly: InternalsVisibleTo("DotNetNuke.Tests.Web")]
[assembly: InternalsVisibleTo("DotNetNuke.Tests.Web.Mvc")]
[assembly: InternalsVisibleTo("DotNetNuke.Tests.Urls")]
[assembly: InternalsVisibleTo("DotNetNuke.Tests.Professional")]
[assembly: InternalsVisibleTo("DotNetNuke.SiteExportImport")]
[assembly: InternalsVisibleTo("DotNetNuke.Web.DDRMenu")] // Once Globals is refeactored to Dependency Injection we should be able to remove this
[assembly: InternalsVisibleTo("Dnn.PersonaBar.Extensions")] // Once Globals is refeactored to Dependency Injection we should be able to remove this
[assembly: InternalsVisibleTo("DotNetNuke.Modules.Html")] // Once Globals is refeactored to Dependency Injection we should be able to remove this
[assembly: InternalsVisibleTo("DotNetNuke.Website.Deprecated")] // Once Globals is refeactored to Dependency Injection we should be able to remove this
[assembly: InternalsVisibleTo("Dnn.PersonaBar.UI")] // Once Globals is refeactored to Dependency Injection we should be able to remove this
[assembly: InternalsVisibleTo("Dnn.PersonaBar.Library")] // Once Globals is refeactored to Dependency Injection we should be able to remove this
[assembly: InternalsVisibleTo("DotNetNuke.Modules.Groups")] // Once Globals is refeactored to Dependency Injection we should be able to remove this