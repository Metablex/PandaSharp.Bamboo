using PandaSharp.Bamboo.Services.Common.Response.Converter;

namespace PandaSharp.Bamboo.Services.Build.Response.Converter
{
    internal sealed class LabelListResponseConverter : JsonListResponseConverterBase<LabelResponse>
    {
        protected override string ItemsPath => "label";
    }
}