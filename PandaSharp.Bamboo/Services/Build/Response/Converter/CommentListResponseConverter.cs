using PandaSharp.Bamboo.Services.Common.Response.Converter;

namespace PandaSharp.Bamboo.Services.Build.Response.Converter
{
    internal sealed class CommentListResponseConverter : JsonListResponseConverterBase<CommentResponse>
    {
        protected override string ItemsPath => "comment";
    }
}