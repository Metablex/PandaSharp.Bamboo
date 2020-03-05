using System;
using System.Reflection;
using Newtonsoft.Json;
using NUnit.Framework;
using PandaSharp.Bamboo.Attributes;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Common.Response
{
    [TestFixture]
    public abstract class ListResponseTestBase<T> : ResponseTestBase<T>
        where T : class, new()
    {
        [Test]
        public void ListResponseTest()
        {
            var responseType = typeof(T);

            var converterAttribute = responseType.GetCustomAttribute<JsonConverterAttribute>();
            converterAttribute.ShouldNotBeNull();
            InheritsFrom(converterAttribute.ConverterType, typeof(JsonConverter<T>)).ShouldBeTrue();

            responseType.GetCustomAttribute<JsonItemsAttribute>().ShouldNotBeNull();
        }

        private bool InheritsFrom(Type type, Type baseType)
        {
            var nextBaseType = type.BaseType;
            while (nextBaseType != null)
            {
                if (nextBaseType == baseType)
                {
                    return true;
                }

                nextBaseType = nextBaseType.BaseType;
            }

            return false;
        }
    }
}