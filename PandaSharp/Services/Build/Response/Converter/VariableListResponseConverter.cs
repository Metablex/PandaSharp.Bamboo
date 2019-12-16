using PandaSharp.Services.Common.Response.Converter;

namespace PandaSharp.Services.Build.Response.Converter
{
    internal sealed class VariableListResponseConverter : JsonListResponseConverterBase<VariableResponse>
    {
        protected override string ItemsPath => "variable";
    }
}