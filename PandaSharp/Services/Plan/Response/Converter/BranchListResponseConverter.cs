using PandaSharp.Services.Common.Response.Converter;

namespace PandaSharp.Services.Plan.Response.Converter
{
    internal sealed class BranchListResponseConverter : JsonListResponseConverterBase<BranchResponse>
    {
        protected override string ItemsPath => "branch";
    }
}