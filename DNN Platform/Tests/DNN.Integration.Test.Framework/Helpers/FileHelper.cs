﻿// DNN® and DotNetNuke® - http://www.DNNSoftware.com
// Copyright ©2002-2019
// by DNN Corp

using System.IO;
using System.Reflection;

namespace DNN.Integration.Test.Framework.Helpers
{
    public static class FileHelper
    {
        public static string GetAbsoluteDir(string relativePathIn)
        {
            if (!relativePathIn.StartsWith("\\")) relativePathIn = "\\" + relativePathIn;

            var rootDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var pathOut = rootDirectory + relativePathIn;

            return pathOut;
        }
    }
}
