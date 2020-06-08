﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information
using System;
using System.Runtime.Serialization;

namespace DotNetNuke.Services.FileSystem
{
    [Serializable]
    public class InvalidFilenameException : Exception
    {
        public InvalidFilenameException()
        {
        }

        public InvalidFilenameException(string message)
            : base(message)
        {
        }

        public InvalidFilenameException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public InvalidFilenameException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
