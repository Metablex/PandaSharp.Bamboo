using PandaSharp.Bamboo.Services.Common.Response.Converter;

namespace PandaSharp.Bamboo.Services.Build.Response.Converter
{
    internal sealed class VariableListResponseConverter : JsonListResponseConverterBase<VariableResponse>
    {
        protected override string ItemsPath => "variable";
    }
}