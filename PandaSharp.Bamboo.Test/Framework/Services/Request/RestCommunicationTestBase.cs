using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using Moq;
using NUnit.Framework;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using RestSharp;

namespace PandaSharp.Bamboo.Test.Framework.Services.Request
{
    [TestFixture]
    internal abstract class RestCommunicationTestBase<TRequest>
    {
        private Mock<IRequestParameterAspectFactory> _parameterAspectFactoryMock;
        private Mock<IRestFactory> _restFactoryMock;
        private Mock<IRestRequest> _restRequestMock;
        private List<Mock<IRequestParameterAspect>> _parameterAspectMocks;


        [SetUp]
        public void SetupRequestTest()
        {
            SetupRestRequest();
            SetupParameterAspects();
            SetupEachTest();
        }

        protected virtual void SetupEachTest()
        {
        }

        protected abstract Mock<IRestClient> SetupRestClientMock();

        protected virtual IEnumerable<Mock<IRequestParameterAspect>> InitializeParameterAspectMocks()
        {
            return Enumerable.Empty<Mock<IRequestParameterAspect>>();
        }

        protected Mock<IRequestParameterAspect> CreateParameterAspectMock<TAspect>(Action<Mock<TAspect>> setupAspect = null)
            where TAspect : class
        {
            var mock = new Mock<TAspect>(MockBehavior.Strict);
            setupAspect?.Invoke(mock);

            var aspectMock = mock
                .As<IRequestParameterAspect>()
                .SetupAllProperties();

            aspectMock.Setup(i => i.ApplyToRestRequest(It.IsAny<IRestRequest>()));

            return aspectMock;
        }

        protected Mock<TAspect> GetParameterAspectMock<TAspect>()
            where TAspect : class
        {
            var mock = _parameterAspectMocks.FirstOrDefault(i => i.Object is TAspect);
            if (mock == null)
            {
                throw new InvalidOperationException($"Mock with type {typeof(TAspect)} could not be found.");
            }

            return mock.As<TAspect>();
        }

        protected Mock<IRestRequest> GetRestRequestMock()
        {
            return _restRequestMock;
        }

        protected TRequest CreateRequest()
        {
            return (TRequest)Activator.CreateInstance(
                typeof(TRequest),
                _restFactoryMock.Object,
                _parameterAspectFactoryMock.Object);
        }

        protected void VerifyParameterAspectMock<TAspect>(Action<TAspect> validate)
            where TAspect : class
        {
            var mock = GetParameterAspectMock<TAspect>();
            validate(mock.Object);
        }

        protected void VerifyRestRequestCreation(string expectedResource, Method expectedMethod)
        {
            _restFactoryMock.Verify(r => r.CreateRequest(expectedResource, expectedMethod), Times.Once);

            foreach (var aspectMock in _parameterAspectMocks)
            {
                aspectMock.Verify(i => i.ApplyToRestRequest(It.IsAny<IRestRequest>()), Times.Once);
            }
        }

        protected static bool IsResponseSuccessful()
        {
            var attribute = GetRequestStatusCodeAttribute();
            if (attribute == null)
            {
                return true;
            }

            return attribute.IsSuccessful;
        }

        protected static HttpStatusCode GetResponseStatusCode()
        {
            var attribute = GetRequestStatusCodeAttribute();
            if (attribute == null)
            {
                return HttpStatusCode.OK;
            }

            return attribute.StatusCode;
        }

        protected static string GetResponseErrorMessage()
        {
            var attribute = GetRequestStatusCodeAttribute();
            if (attribute == null)
            {
                return string.Empty;
            }

            return attribute.ErrorMessage;
        }

        private void SetupParameterAspects()
        {
            _parameterAspectMocks = new List<Mock<IRequestParameterAspect>>();
            _parameterAspectMocks.AddRange(InitializeParameterAspectMocks());

            _parameterAspectFactoryMock = new Mock<IRequestParameterAspectFactory>(MockBehavior.Strict);
            _parameterAspectFactoryMock
                .Setup(i => i.GetParameterAspects(It.Is<Type>(t => t == typeof(TRequest))))
                .Returns(_parameterAspectMocks.Select(m => m.Object).ToList);
        }

        private void SetupRestRequest()
        {
            _restRequestMock = new Mock<IRestRequest>();

            var client = SetupRestClientMock();

            _restFactoryMock = new Mock<IRestFactory>(MockBehavior.Strict);
            _restFactoryMock
                .Setup(i => i.CreateClient())
                .Returns(client.Object);

            _restFactoryMock
                .Setup(i => i.CreateRequest(It.IsAny<string>(), It.IsAny<Method>()))
                .Returns(_restRequestMock.Object);
        }

        private static TestRequestStatusCodeAttribute GetRequestStatusCodeAttribute()
        {
            var currentTestMethod = Type
                .GetType(TestContext.CurrentContext.Test.ClassName)?
                .GetMethod(TestContext.CurrentContext.Test.MethodName);

            if (currentTestMethod == null)
            {
                throw new InvalidOperationException("Test method could not be found.");
            }

            return currentTestMethod.GetCustomAttribute<TestRequestStatusCodeAttribute>();
        }
    }
}