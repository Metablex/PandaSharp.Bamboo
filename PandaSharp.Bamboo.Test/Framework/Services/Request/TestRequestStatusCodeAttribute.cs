using System;
using System.Net;

namespace PandaSharp.Bamboo.Test.Framework.Services.Request
{
    internal sealed class TestRequestStatusCodeAttribute : Attribute
    {
        public bool IsSuccessful => StatusCode == HttpStatusCode.OK;

        public HttpStatusCode StatusCode { get; }

        public string ErrorMessage { get; }

        public TestRequestStatusCodeAttribute(HttpStatusCode statusCode, string errorMessage = null)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage ?? string.Empty;
        }
    }
}