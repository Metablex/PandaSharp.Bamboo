using PandaSharp.Services.Common.Response.Converter;

namespace PandaSharp.Services.Plan.Response.Converter
{
    internal sealed class VariableContextListResponseConverter : JsonListResponseConverterBase<VariableResponse>
    {
        protected override string ItemsPath => "variable";
    }
}