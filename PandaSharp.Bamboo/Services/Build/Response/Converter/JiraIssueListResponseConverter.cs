using PandaSharp.Bamboo.Services.Common.Response.Converter;

namespace PandaSharp.Bamboo.Services.Build.Response.Converter
{
    internal sealed class JiraIssueListResponseConverter : JsonListResponseConverterBase<JiraIssueResponse>
    {
        protected override string ItemsPath => "issue";
    }
}