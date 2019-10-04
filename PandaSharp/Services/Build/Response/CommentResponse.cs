using System;
using RestSharp.Deserializers;

namespace PandaSharp.Services.Build.Response
{
    public sealed class CommentResponse
    {
        [DeserializeAs(Name = "author")]
        public string Author { get; set; }

        [DeserializeAs(Name = "content")]
        public string Content { get; set; }

        [DeserializeAs(Name = "creationDate")]
        public DateTime CreationDate { get; set; }

        [DeserializeAs(Name = "modificationDate")]
        public DateTime Modification { get; set; }
    }
}