using PandaSharp.Services.Common.Response.Converter;

namespace PandaSharp.Services.Build.Response.Converter
{
    internal sealed class JiraIssueListResponseConverter : JsonListResponseConverterBase<JiraIssueResponse>
    {
        protected override string ItemsPath => "issue";
    }
}