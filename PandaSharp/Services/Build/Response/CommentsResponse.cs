using System.Collections.Generic;
using PandaSharp.Services.Common.Response;
using RestSharp.Deserializers;

namespace PandaSharp.Services.Build.Response
{
    public sealed class CommentsResponse : ListResponseBase
    {
        [DeserializeAs(Name = "comment")]
        public List<CommentResponse> Contents { get; set; }
    }
}