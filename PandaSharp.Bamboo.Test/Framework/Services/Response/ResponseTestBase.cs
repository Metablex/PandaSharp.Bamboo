using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using NUnit.Framework;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Framework.Services.Response
{
    [TestFixture]
    public abstract class ResponseTestBase<T>
        where T : class, new()
    {
        [Test]
        public void ResponseObjectAttributesTest()
        {
            var response = new T();
            foreach (var property in GetPropertiesForTest(response))
            {
                property
                    .SetMethod
                    .Attributes
                    .HasFlag(MethodAttributes.Private)
                    .ShouldBeFalse($"Property {property.Name} must have public setter");

                property
                    .GetMethod
                    .Attributes
                    .HasFlag(MethodAttributes.Private)
                    .ShouldBeFalse($"Property {property.Name} must have public getter");

                var attribute = property.GetCustomAttribute<JsonPropertyAttribute>();
                attribute.ShouldNotBeNull();
                attribute.PropertyName.ShouldNotBeNull();

                var testValue = CreateTestValueOf(property.PropertyType);
                property.SetValue(response, testValue);

                var actualValue = property.GetValue(response);
                actualValue.ShouldBe(testValue);
            }
        }

        private static IEnumerable<PropertyInfo> GetPropertiesForTest(T response)
        {
            return response
                .GetType()
                .GetProperties()
                .Where(p => p.Module.Assembly.FullName.Contains("PandaSharp"));
        }

        private static object CreateTestValueOf(Type propertyType)
        {
            if (propertyType == typeof(string))
            {
                return "TestString";
            }

            if (propertyType == typeof(int))
            {
                return new Random().Next();
            }

            if (propertyType == typeof(bool))
            {
                return true;
            }

            return Activator.CreateInstance(propertyType);
        }
    }
}