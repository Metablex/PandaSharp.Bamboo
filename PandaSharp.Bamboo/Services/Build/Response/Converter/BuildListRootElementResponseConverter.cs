using PandaSharp.Bamboo.Services.Common.Response.Converter;

namespace PandaSharp.Bamboo.Services.Build.Response.Converter
{
    internal sealed class BuildListRootElementResponseConverter : RootElementResponseConverterBase<BuildListResponse, BuildResponse>
    {
        protected override string RootElement => "results";
    }
}