using PandaSharp.Services.Common.Response.Converter;

namespace PandaSharp.Services.Build.Response.Converter
{
    internal sealed class ArtifactListResponseConverter : JsonListResponseConverterBase<ArtifactResponse>
    {
        protected override string ItemsPath => "artifact";
    }
}