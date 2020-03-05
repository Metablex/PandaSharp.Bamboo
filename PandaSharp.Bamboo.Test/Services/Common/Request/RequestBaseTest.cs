using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Rest.Contract;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Common.Request;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Common.Request
{
    [TestFixture]
    internal abstract class RequestBaseTest<TRequest, TResponse>
        where TRequest : RequestBase<TResponse>
        where TResponse : class, new()
    {
        private Mock<IRequestParameterAspectFactory> _parameterAspectFactoryMock;
        private Mock<IRestFactory> _restFactoryMock;
        private List<Mock<IRequestParameterAspect>> _parameterAspectMocks;

        [SetUp]
        public void SetupRequestTest()
        {
            SetupRestRequest();
            SetupParameterAspects();
        }

        [Test]
        [TestRequestStatusCode(HttpStatusCode.Unauthorized)]
        public void UnauthorizedExecuteTest()
        {
            var request = CreateRequest();

            Should.ThrowAsync<UnauthorizedAccessException>(() => request.ExecuteAsync());
        }

        [Test]
        [TestRequestStatusCode(HttpStatusCode.NotFound)]
        public void AnyErrorWhileExecuteTest()
        {
            var request = CreateRequest();

            Should.ThrowAsync<InvalidOperationException>(() => request.ExecuteAsync());
        }

        protected Mock<IRequestParameterAspect> CreateParameterAspectMock<TAspect>()
            where TAspect : class
        {
            var mock = new Mock<TAspect>(MockBehavior.Strict)
                .As<IRequestParameterAspect>()
                .SetupAllProperties();

            mock.Setup(i => i.ApplyToRestRequest(It.IsAny<IRestRequest>()));
            return mock;
        }

        protected void ValidateParameterAspectMock<TAspect>(Action<TAspect> validate)
            where TAspect : class
        {
            var mock = _parameterAspectMocks.FirstOrDefault(i => i.Object is TAspect);
            if (mock == null)
            {
                throw new InvalidOperationException($"Mock with type {typeof(TAspect)} could not be found.");
            }

            validate(mock.As<TAspect>().Object);
        }

        protected TRequest CreateRequest()
        {
            return (TRequest)Activator.CreateInstance(
                typeof(TRequest),
                _restFactoryMock.Object,
                _parameterAspectFactoryMock.Object);
        }

        protected virtual IEnumerable<Mock<IRequestParameterAspect>> InitializeParameterAspectMocks()
        {
            return Enumerable.Empty<Mock<IRequestParameterAspect>>();
        }

        protected void VerifyRestRequestCreation(string expectedResource, Method expectedMethod)
        {
            _restFactoryMock.Verify(r => r.CreateRequest(expectedResource, expectedMethod), Times.Once);

            foreach (var aspectMock in _parameterAspectMocks)
            {
                aspectMock.Verify(i => i.ApplyToRestRequest(It.IsAny<IRestRequest>()), Times.Once);
            }
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
            _restFactoryMock = new Mock<IRestFactory>(MockBehavior.Strict);

            var response = new Mock<IRestResponse<TResponse>>(MockBehavior.Loose);
            response
                .SetupGet(i => i.IsSuccessful)
                .Returns(IsResponseSuccessful);

            response
                .SetupGet(i => i.StatusCode)
                .Returns(GetResponseStatusCode);

            response
                .SetupGet(i => i.ErrorMessage)
                .Returns(GetResponseErrorMessage);

            response
                .SetupGet(i => i.Data)
                .Returns(new TResponse());

            var client = new Mock<IRestClient>(MockBehavior.Strict);
            client
                .Setup(i => i.ExecuteTaskAsync<TResponse>(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()))
                .Returns(Task.Run(() => response.Object));

            _restFactoryMock
                .Setup(i => i.CreateClient())
                .Returns(client.Object);

            _restFactoryMock
                .Setup(i => i.CreateRequest(It.IsAny<string>(), It.IsAny<Method>()))
                .Returns(new Mock<IRestRequest>().Object);
        }

        private static bool IsResponseSuccessful()
        {
            var attribute = GetRequestStatusCodeAttribute();
            if (attribute == null)
            {
                return true;
            }

            return attribute.IsSuccessful;
        }

        private static HttpStatusCode GetResponseStatusCode()
        {
            var attribute = GetRequestStatusCodeAttribute();
            if (attribute == null)
            {
                return HttpStatusCode.OK;
            }

            return attribute.StatusCode;
        }

        private static string GetResponseErrorMessage()
        {
            var attribute = GetRequestStatusCodeAttribute();
            if (attribute == null)
            {
                return string.Empty;
            }

            return attribute.ErrorMessage;
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