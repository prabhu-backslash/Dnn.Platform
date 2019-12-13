﻿// 
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// 
using System.Web;
using DotNetNuke.Web.Mvc.Framework.Modules;
using DotNetNuke.Web.Mvc.Routing;
using Moq;
using NUnit.Framework;

namespace DotNetNuke.Tests.Web.Mvc.Routing
{
    [TestFixture]
    public class HttpContextExtensionsTests
    {
        [Test]
        public void GetModuleRequestResult_Returns_ModuleRequestResult_If_Present()
        {
            //Arrange
            var httpContext = MockHelper.CreateMockHttpContext();
            var expectedResult = new ModuleRequestResult();
            httpContext.Items[HttpContextExtensions.ModuleRequestResultKey] = expectedResult;

            //Act
            var result = httpContext.GetModuleRequestResult();

            //Assert
            Assert.AreSame(expectedResult, result);
        }

        [Test]
        public void GetModuleRequestResult_Returns_Null_If_Not_Present()
        {
            //Arrange
            var httpContext = MockHelper.CreateMockHttpContext();

            //Act
            var result = httpContext.GetModuleRequestResult();

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void HasModuleRequestResult_Returns_True_If_Present()
        {
            // Arrange
            HttpContextBase httpContext = MockHelper.CreateMockHttpContext();
            var expectedResult = new ModuleRequestResult();
            httpContext.Items[HttpContextExtensions.ModuleRequestResultKey] = expectedResult;

            //Act and Assert
            Assert.IsTrue(httpContext.HasModuleRequestResult());
        }

        [Test]
        public void HasModuleRequestResult_Returns_False_If_Not_Present()
        {
            // Arrange
            HttpContextBase httpContext = MockHelper.CreateMockHttpContext();

            // Act and Assert
            Assert.IsFalse(httpContext.HasModuleRequestResult());
        }

        [Test]
        public void SetModuleRequestResult_Sets_ModuleRequestResult()
        {
            // Arrange
            HttpContextBase context = MockHelper.CreateMockHttpContext();
            var expectedResult = new ModuleRequestResult();

            // Act
            context.SetModuleRequestResult(expectedResult);

            // Assert
            var actual = context.Items[HttpContextExtensions.ModuleRequestResultKey];
            Assert.IsNotNull(actual);
            Assert.IsInstanceOf<ModuleRequestResult>(actual);
        }
    }
}
