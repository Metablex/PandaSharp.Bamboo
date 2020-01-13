using PandaSharp.Bamboo.Services.Common.Response.Converter;

namespace PandaSharp.Bamboo.Services.Build.Response.Converter
{
    internal sealed class ArtifactListResponseConverter : JsonListResponseConverterBase<ArtifactResponse>
    {
        protected override string ItemsPath => "artifact";
    }
}