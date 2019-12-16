using PandaSharp.Services.Common.Response.Converter;

namespace PandaSharp.Services.Build.Response.Converter
{
    internal sealed class LabelListResponseConverter : JsonListResponseConverterBase<LabelResponse>
    {
        protected override string ItemsPath => "label";
    }
}