#region Copyright
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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using DotNetNuke.Common;
using DotNetNuke.Common.Utilities.Internal;
using DotNetNuke.Framework;

namespace DotNetNuke.Entities.Portals.Internal
{
    public class PortalTemplateIO : ServiceLocator<IPortalTemplateIO, PortalTemplateIO>, IPortalTemplateIO
    {
        protected override Func<IPortalTemplateIO> GetFactory()
        {
            return () => new PortalTemplateIO();
        }

        #region IPortalTemplateIO Members

        public IEnumerable<string> EnumerateTemplates()
        {
            string path = Globals.HostMapPath;
            if (Directory.Exists(path))
            {
                return Directory.GetFiles(path, "*.template").Where(x => Path.GetFileNameWithoutExtension(x) != "admin");
            }

            return new string[0];
        }

        public IEnumerable<string> EnumerateLanguageFiles()
        {
            string path = Globals.HostMapPath;
            if (Directory.Exists(path))
            {
                return Directory.GetFiles(path, "*.template.??-??.resx");
            }

            return new string[0];
        }

        public string GetResourceFilePath(string templateFilePath)
        {
            return CheckFilePath(templateFilePath + ".resources");
        }

        public string GetLanguageFilePath(string templateFilePath, string cultureCode)
        {
            return CheckFilePath(string.Format("{0}.{1}.resx", templateFilePath, cultureCode));
        }

        public TextReader OpenTextReader(string filePath)
        {
            StreamReader reader = null;
            
            var retryable = new RetryableAction(
                () => reader = new StreamReader(File.Open(filePath, FileMode.Open)),
                filePath, 10, TimeSpan.FromMilliseconds(50), 2);

            retryable.TryIt();
            return reader;
        }

        private static string CheckFilePath(string path)
        {
            return File.Exists(path) ? path : string.Empty;
        }

        #endregion
    }
}