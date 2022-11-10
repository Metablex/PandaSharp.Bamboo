﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Services.Contract;
using RestSharp;

namespace PandaSharp.Bamboo.Test.Framework.Services.Request
{
    internal static class RequestTestMockBuilder
    {
        internal static TRequest CreateRequest<TRequest, TResponse>(
            Mock<IRestFactory> restFactoryMock,
            params Mock[] parameterAspects)
            where TRequest : IRequestBase<TResponse>
        {
            var requestParameterAspectFactoryMock = CreateRequestParameterAspectFactoryMock(parameterAspects);
            var restResponseConverterFactory = CreateRestResponseConverterFactoryMock<TResponse>();

            return (TRequest)Activator.CreateInstance(
                typeof(TRequest),
                restFactoryMock.Object,
                requestParameterAspectFactoryMock.Object,
                restResponseConverterFactory.Object);
        }

        internal static TRequest CreateCommand<TRequest>(
            Mock<IRestFactory> restFactoryMock,
            params Mock[] parameterAspects)
            where TRequest : ICommandBase
        {
            var requestParameterAspectFactoryMock = CreateRequestParameterAspectFactoryMock(parameterAspects);

            return (TRequest)Activator.CreateInstance(
                typeof(TRequest),
                restFactoryMock.Object,
                requestParameterAspectFactoryMock.Object);
        }

        internal static Mock<IRestFactory> CreateRestFactoryMock<TResponse>(HttpStatusCode responseCode = HttpStatusCode.OK, Mock<IRestRequest> restRequestMock = null)
            where TResponse : class, new()
        {
            var response = new Mock<IRestResponse<TResponse>>();
            response
                .SetupGet(i => i.IsSuccessful)
                .Returns(responseCode == HttpStatusCode.OK);

            response
                .SetupGet(i => i.StatusCode)
                .Returns(responseCode);

            response
                .SetupGet(i => i.Data)
                .Returns(new TResponse());

            var mock = restRequestMock ?? new Mock<IRestRequest>();

            var client = new Mock<IRestClient>(MockBehavior.Strict);
            client
                .Setup(i => i.ExecuteAsync<TResponse>(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()))
                .Returns(Task.Run(() => response.Object));

            var restFactoryMock = new Mock<IRestFactory>(MockBehavior.Strict);
            restFactoryMock
                .Setup(i => i.CreateClient())
                .Returns(client.Object);

            restFactoryMock
                .Setup(i => i.CreateRequest(It.IsAny<string>(), It.IsAny<Method>()))
                .Returns(mock.Object);

            return restFactoryMock;
        }

        internal static Mock<IRestFactory> CreateRestFactoryMock(HttpStatusCode responseCode = HttpStatusCode.OK, Mock<IRestRequest> restRequestMock = null)
        {
            var response = new Mock<IRestResponse>();
            response
                .SetupGet(i => i.IsSuccessful)
                .Returns(responseCode == HttpStatusCode.OK);

            response
                .SetupGet(i => i.StatusCode)
                .Returns(responseCode);

            var client = new Mock<IRestClient>(MockBehavior.Strict);
            client
                .Setup(i => i.ExecuteAsync(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()))
                .Returns(Task.Run(() => response.Object));

            var mock = restRequestMock ?? new Mock<IRestRequest>();

            var restFactoryMock = new Mock<IRestFactory>(MockBehavior.Strict);
            restFactoryMock
                .Setup(i => i.CreateClient())
                .Returns(client.Object);

            restFactoryMock
                .Setup(i => i.CreateRequest(It.IsAny<string>(), It.IsAny<Method>()))
                .Returns(mock.Object);

            return restFactoryMock;
        }

        internal static Mock<TAspect> CreateParameterAspectMock<TAspect>()
            where TAspect : class
        {
            var mock = new Mock<TAspect>();

            mock.As<IRequestParameterAspect>().Setup(i => i.ApplyToRestRequest(It.IsAny<IRestRequest>()));

            return mock;
        }

        private static Mock<IRequestParameterAspectFactory> CreateRequestParameterAspectFactoryMock(IList<Mock> parameterAspects)
        {
            var parameterAspectFactoryMock = new Mock<IRequestParameterAspectFactory>(MockBehavior.Strict);
            parameterAspectFactoryMock
                .Setup(i => i.GetParameterAspects(It.IsAny<Type>()))
                .Returns(parameterAspects.Select(i => i.As<IRequestParameterAspect>().Object).ToArray());

            return parameterAspectFactoryMock;
        }

        private static Mock<IRestResponseConverterFactory> CreateRestResponseConverterFactoryMock<TResponse>()
        {
            var restResponseConverterFactoryMock = new Mock<IRestResponseConverterFactory>();
            var restResponseConverterMock = new Mock<IRestResponseConverter>();

            restResponseConverterFactoryMock
                .Setup(i => i.CreateResponseConverter(It.IsAny<Type>()))
                .Returns(restResponseConverterMock.Object);

            restResponseConverterMock
                .Setup(i => i.ConvertRestResponse(It.IsAny<IRestResponse<TResponse>>()))
                .Returns<IRestResponse<TResponse>>(response => response.Data);

            return restResponseConverterFactoryMock;
        }
    }
}