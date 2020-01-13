using PandaSharp.Bamboo.Services.Common.Response.Converter;

namespace PandaSharp.Bamboo.Services.Build.Response.Converter
{
    internal sealed class MetadataListResponseConverter : JsonListResponseConverterBase<MetadataResponse>
    {
        protected override string ItemsPath => "item";
    }
}