﻿using System;
using System.Runtime.Serialization;

using DotNetNuke.Services.Exceptions;

namespace DotNetNuke.Services.FileSystem
{
    [Serializable]
    public class InvalidFileExtensionException : Exception
    {
        public InvalidFileExtensionException()
        {
        }

        public InvalidFileExtensionException(string message)
            : base(message)
        {
        }

        public InvalidFileExtensionException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public InvalidFileExtensionException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
