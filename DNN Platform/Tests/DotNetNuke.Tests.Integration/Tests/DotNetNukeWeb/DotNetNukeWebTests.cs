﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information
using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Web;
using DNN.Integration.Test.Framework;
using NUnit.Framework;

namespace DotNetNuke.Tests.Integration.Tests.DotNetNukeWeb
{
    [TestFixture]
    public class DotNetNukeWebTests : IntegrationTestBase
    {
        #region private data

        private readonly HttpClient _httpClient;

        private readonly TimeSpan _timeout = TimeSpan.FromSeconds(30);

        private const string GetMonikerQuery = "/API/web/mobilehelper/monikers?moduleList=";
        private const string GetModuleDetailsQuery = "/API/web/mobilehelper/moduledetails?moduleList=";

        public DotNetNukeWebTests()
        {
            var url = ConfigurationManager.AppSettings["siteUrl"];
            var siteUri = new Uri(url);
            _httpClient = new HttpClient { BaseAddress = siteUri, Timeout = _timeout };
        }

        #endregion

        #region tests

        [Test]
        [TestCase(GetMonikerQuery)]
        [TestCase(GetModuleDetailsQuery)]
        public void CallingHelperForAnonymousUserShouldReturnSuccess(string query)
        {
            var result = _httpClient.GetAsync(query + HttpUtility.UrlEncode("ViewProfile")).Result;
            var content = result.Content.ReadAsStringAsync().Result;
            LogText(@"content => " + content);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        #endregion
    }
}
