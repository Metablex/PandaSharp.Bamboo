using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Common.Response.Converter;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Common.Response.Converter
{
    [TestFixture]
    public sealed class JsonListResponseConverterTest
    {
        [Test]
        public void ConverterWriteTest()
        {
            var memoryStream = new MemoryStream();
            var streamWriter = new StreamWriter(memoryStream);
            var writer = new JsonTextWriter(streamWriter);

            var converter = new JsonListResponseConverter<TestResponse>("test");
            converter.CanWrite.ShouldBeFalse();
            converter.WriteJson(writer, new List<TestResponse>(), new JsonSerializer());

            memoryStream.Length.ShouldBe(0);
        }

        [Test]
        public void ConverterReadTest()
        {
            var reader = CreateTestReader();

            var converter = new JsonListResponseConverter<TestResponse>("plans.plan");
            converter.CanRead.ShouldBeTrue();
            var result = converter.ReadJson(reader, typeof(TestResponse), new List<TestResponse>(), false, new JsonSerializer());

            result.ShouldNotBeNull();
            result.Select(r => r.Name).ShouldBe(new[] { "READ", "WRITE" });
        }

        [Test]
        public void ConverterReadWrongPathTest()
        {
            var reader = CreateTestReader();

            var converter = new JsonListResponseConverter<TestResponse>("actions");
            converter.CanRead.ShouldBeTrue();
            var emptyResult = converter.ReadJson(reader, typeof(TestResponse), new List<TestResponse>(), false, new JsonSerializer());

            emptyResult.ShouldBeEmpty();
        }

        private JsonTextReader CreateTestReader()
        {
            var json = @"
            {
                ""plans"": {
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
    }
}