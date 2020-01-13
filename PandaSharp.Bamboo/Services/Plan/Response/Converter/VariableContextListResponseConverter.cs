using PandaSharp.Bamboo.Services.Common.Response.Converter;

namespace PandaSharp.Bamboo.Services.Plan.Response.Converter
{
    internal sealed class VariableContextListResponseConverter : JsonListResponseConverterBase<VariableResponse>
    {
        protected override string ItemsPath => "variable";
    }
}