﻿using NUnit.Framework;
using Shouldly;

namespace PandaSharp.Bamboo.Test
{
    [TestFixture]
    public sealed class BambooApiFactoryTest
    {
        [Test]
        public void BambooApiBasicConstructionTest()
        {
            var bambooApi = BambooApiFactory.CreateWithBasicAuthentication("http://test.bamboo.com", "TestBob", "admin01");

            bambooApi.BuildRequest.ShouldNotBeNull();
            bambooApi.PlanRequest.ShouldNotBeNull();
            bambooApi.SearchRequest.ShouldNotBeNull();
            bambooApi.UsersRequest.ShouldNotBeNull();
            bambooApi.ProjectRequest.ShouldNotBeNull();
        }

        [Test]
        public void BambooApiOAuthConstructionTest()
        {
            var bambooApi = BambooApiFactory.CreateWithOAuthAuthentication("http://test.bamboo.com", "TestBob", "admin01", "token", "tokenSecret");

            bambooApi.BuildRequest.ShouldNotBeNull();
            bambooApi.PlanRequest.ShouldNotBeNull();
            bambooApi.SearchRequest.ShouldNotBeNull();
            bambooApi.UsersRequest.ShouldNotBeNull();
            bambooApi.ProjectRequest.ShouldNotBeNull();
        }
    }
}