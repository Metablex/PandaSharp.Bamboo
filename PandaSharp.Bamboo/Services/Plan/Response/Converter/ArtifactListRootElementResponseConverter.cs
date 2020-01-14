using PandaSharp.Bamboo.Services.Common.Response.Converter;

namespace PandaSharp.Bamboo.Services.Plan.Response.Converter
{
    internal class ArtifactListRootElementResponseConverter : RootElementResponseConverterBase<ArtifactListResponse, ArtifactResponse>
    {
        protected override string RootElement => "artifacts";
    }
}