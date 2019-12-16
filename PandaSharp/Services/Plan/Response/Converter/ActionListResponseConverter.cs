using PandaSharp.Services.Common.Response.Converter;

namespace PandaSharp.Services.Plan.Response.Converter
{
    internal sealed class ActionListResponseConverter : JsonListResponseConverterBase<ActionResponse>
    {
        protected override string ItemsPath => "action";
    }
}