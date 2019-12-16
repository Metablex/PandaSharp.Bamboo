using PandaSharp.Services.Common.Response.Converter;

namespace PandaSharp.Services.Build.Response.Converter
{
    internal sealed class MetadataListResponseConverter : JsonListResponseConverterBase<MetadataResponse>
    {
        protected override string ItemsPath => "item";
    }
}