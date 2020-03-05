using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using NUnit.Framework;
using PandaSharp.Bamboo.Attributes;
using PandaSharp.Bamboo.Services.Common.Response;
using PandaSharp.Bamboo.Services.Common.Response.Converter;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Common.Response.Converter
{
    [TestFixture]
    public sealed class RootElementResponseConverterTest
    {
        [Test]
        public void ConverterWriteTest()
        {
            var memoryStream = new MemoryStream();
            var streamWriter = new StreamWriter(memoryStream);
            var writer = new JsonTextWriter(streamWriter);

            var converter = new RootElementResponseConverter<TestListResponse, TestResponse>();
            converter.CanWrite.ShouldBeFalse();
            converter.WriteJson(writer, new TestListResponse(), new JsonSerializer());

            memoryStream.Length.ShouldBe(0);
        }

        [Test]
        public void ConverterReadTest()
        {
            var reader = CreateTestReader();

            var converter = new RootElementResponseConverter<TestListResponse, TestResponse>();
            converter.CanRead.ShouldBeTrue();
            var result = converter.ReadJson(reader, typeof(TestResponse), new TestListResponse(), false, new JsonSerializer());

            result.ShouldNotBeNull();
            result.Number.ShouldBe(42);
            result.Select(r => r.Name).ShouldBe(new[] { "READ", "WRITE" });
        }

        [Test]
        public void ConverterReadNoRootElementTest()
        {
            var reader = CreateTestReader();

            var converter = new RootElementResponseConverter<TestListNoRootResponse, TestResponse>();
            converter.CanRead.ShouldBeTrue();
            var result = converter.ReadJson(reader, typeof(TestResponse), new TestListNoRootResponse(), false, new JsonSerializer());

            result.ShouldNotBeNull();
            result.Select(r => r.Name).ShouldBe(new[] { "READ", "WRITE" });
        }

        private static JsonTextReader CreateTestReader()
        {
            const string json = @"
            {
                ""plans"": {
                    ""number"":""42"",
                    ""plan"": [
                        {
						    ""name"": ""READ""
                        },
                        {
						    ""name"": ""WRITE""
                        },
                    ]
                }
            }";

            var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(json));
            var streamReader = new StreamReader(memoryStream);
            return new JsonTextReader(streamReader);
        }

        private sealed class TestResponse
        {
            [JsonProperty("name")]
            public string Name { get; set; }
        }

        [JsonRootElement("plans")]
        [JsonItems("plan")]
        private sealed class TestListResponse : ListResponseBase<TestResponse>
        {
            [JsonProperty("number")]
            public int Number { get; set; }
        }

        [JsonItems("plans.plan")]
        private sealed class TestListNoRootResponse : ListResponseBase<TestResponse>
        {
        }
    }
}