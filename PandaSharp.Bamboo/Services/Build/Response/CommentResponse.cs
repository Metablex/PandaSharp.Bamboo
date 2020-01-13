using System;
using Newtonsoft.Json;

namespace PandaSharp.Bamboo.Services.Build.Response
{
    public sealed class CommentResponse
    {
        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("creationDate")]
        public DateTime CreationDate { get; set; }

        [JsonProperty("modificationDate")]
        public DateTime Modification { get; set; }
    }
}