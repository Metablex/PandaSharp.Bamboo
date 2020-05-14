using System;
using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.IoC;
using PandaSharp.Bamboo.IoC.Contract;
using PandaSharp.Bamboo.Rest.Contract;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Common.Request;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.IoC
{
    [TestFixture]
    public sealed class RequestProviderRegistrationTest
    {
        [Test]
        public void NoVersionSpecificRegistrationTest()
        {
            var containerMock = new Mock<IPandaContainer>();

            new RequestProviderRegistration<ITestRequest>(containerMock.Object)
                .LatestRequest<TestRequestA>()
                .Register(new PandaContainerContext(new Version()));

            containerMock.Verify(c => c.RegisterType<ITestRequest>(typeof(TestRequestA)), Times.Once);
        }

        [Test]
        public void DoubleLatestRequestRegistrationTest()
        {
            var containerMock = new Mock<IPandaContainer>();

            var registration = new RequestProviderRegistration<ITestRequest>(containerMock.Object)
                .LatestRequest<TestRequestA>();

            Should.Throw<InvalidOperationException>(() => registration.LatestRequest<TestRequestB>());
        }

        [Test]
        public void VersionSpecificRegistrationTest()
        {
            var containerMock = new Mock<IPandaContainer>();

            var registration = new RequestProviderRegistration<ITestRequest>(containerMock.Object)
                .VersionSpecificRequest<TestRequestA>(new Version("1.0.1"))
                .VersionSpecificRequest<TestRequestB>(new Version("1.1.1"))
                .LatestRequest<TestRequestC>();

            var lowerVersion = new PandaContainerContext(new Version("1.0.0"));
            registration.Register(lowerVersion);

            containerMock.Verify(c => c.RegisterType<ITestRequest>(typeof(TestRequestA)));
            containerMock.VerifyNoOtherCalls();

            var middleVersion = new PandaContainerContext(new Version("1.0.6"));
            registration.Register(middleVersion);

            containerMock.Verify(c => c.RegisterType<ITestRequest>(typeof(TestRequestB)));
            containerMock.VerifyNoOtherCalls();

            var higherVersion = new PandaContainerContext(new Version("1.2.1"));
            registration.Register(higherVersion);

            containerMock.Verify(c => c.RegisterType<ITestRequest>(typeof(TestRequestC)));
            containerMock.VerifyNoOtherCalls();

            var matchedVersion = new PandaContainerContext(new Version("1.1.1"));
            registration.Register(matchedVersion);

            containerMock.Verify(c => c.RegisterType<ITestRequest>(typeof(TestRequestB)));
            containerMock.VerifyNoOtherCalls();
        }

        private interface ITestRequest
        {
        }

        private class TestRequestBase : RestCommunicationBase, ITestRequest
        {
            protected TestRequestBase()
                : base(new Mock<IRestFactory>().Object, new Mock<IRequestParameterAspectFactory>().Object)
            {
            }

            protected override string GetResourcePath()
            {
                return "TestPath";
            }

            protected override Method GetRequestMethod()
            {
                return Method.GET;
            }
        }

        private class TestRequestA : TestRequestBase
        {
        }

        private class TestRequestB : TestRequestBase
        {
        }

        private class TestRequestC : TestRequestBase
        {
        }
    }
}