using PandaSharp.Services.Common.Response.Converter;

namespace PandaSharp.Services.Build.Response.Converter
{
    internal sealed class BuildListRootElementResponseConverter : RootElementResponseConverterBase<BuildListResponse, BuildResponse>
    {
        protected override string RootElement => "results";
    }
}