using Newtonsoft.Json;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Services.Converter;
using PandaSharp.Framework.Services.Response;

namespace PandaSharp.Bamboo.Services.Build.Response
{
    [JsonConverter(typeof(RootElementResponseConverter<CommentListResponse, CommentResponse>))]
    [JsonRootElementPath("comments")]
    [JsonListContentPath("comments.comment.[*]")]
    public sealed class CommentListResponse : ListResponseBase<CommentResponse>
    {
    }
}