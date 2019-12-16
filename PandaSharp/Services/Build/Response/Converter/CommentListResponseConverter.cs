using PandaSharp.Services.Common.Response.Converter;

namespace PandaSharp.Services.Build.Response.Converter
{
    internal sealed class CommentListResponseConverter : JsonListResponseConverterBase<CommentResponse>
    {
        protected override string ItemsPath => "comment";
    }
}