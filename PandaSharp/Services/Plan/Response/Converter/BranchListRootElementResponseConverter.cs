using PandaSharp.Services.Common.Response.Converter;

namespace PandaSharp.Services.Plan.Response.Converter
{
    internal class BranchListRootElementResponseConverter : RootElementResponseConverterBase<BranchListResponse, BranchResponse>
    {
        protected override string RootElement => "branches";
    }
}