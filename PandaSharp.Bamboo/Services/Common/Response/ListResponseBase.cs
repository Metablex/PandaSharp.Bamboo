using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace PandaSharp.Bamboo.Services.Common.Response
{
    public abstract class ListResponseBase<T> : IEnumerable<T>
    {
        private readonly List<T> _items = new List<T>();

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("start-index")]
        public int StartIndex { get; set; }

        [JsonProperty("max-result")]
        public int MaxResult { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        [ExcludeFromCodeCoverage]
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void AddResponses(IEnumerable<T> responses)
        {
            _items.AddRange(responses);
        }
    }
}