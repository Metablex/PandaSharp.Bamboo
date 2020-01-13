using System.Collections.Generic;
using Newtonsoft.Json;

namespace PandaSharp.Bamboo.Services.Common.Response
{
    public abstract class ListResponseBase<T> : List<T>
    {
        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("start-index")]
        public int StartIndex { get; set; }

        [JsonProperty("max-result")]
        public int MaxResult { get; set; }
    }
}