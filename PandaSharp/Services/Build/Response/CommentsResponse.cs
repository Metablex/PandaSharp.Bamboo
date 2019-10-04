using System.Collections.Generic;
using PandaSharp.Services.Common.Response;
using RestSharp.Deserializers;

namespace PandaSharp.Services.Build.Response
{
    public sealed class CommentsResponse : ListResponseBase<CommentResponse>
    {
        [DeserializeAs(Name = "comment")]
        public override List<CommentResponse> InnerList { get; set; }
    }
}