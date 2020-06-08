﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information
using System;

namespace DotNetNuke.Tests.Core.ComponentModel.Helpers
{
    public class ServiceImpl : IService
    {
        private static readonly Random rnd = new Random();
        private readonly int id = rnd.Next();

        public int Id
        {
            get { return id; }
        }
    }
}
