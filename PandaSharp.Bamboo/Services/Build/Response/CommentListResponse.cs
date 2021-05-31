using Newtonsoft.Json;
using PandaSharp.Bamboo.Services.Common.Response;
using PandaSharp.Bamboo.Services.Common.Response.Converter;
using PandaSharp.Framework.Attributes;

namespace PandaSharp.Bamboo.Services.Build.Response
{
    [JsonConverter(typeof(RootElementResponseConverter<CommentListResponse, CommentResponse>))]
    [JsonRootElementPath("comments")]
    [JsonListContentPath("comments.comment.[*]")]
    public sealed class CommentListResponse : ListResponseBase<CommentResponse>
    {
    }
}