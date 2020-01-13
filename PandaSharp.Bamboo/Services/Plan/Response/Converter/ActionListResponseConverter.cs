using PandaSharp.Bamboo.Services.Common.Response.Converter;

namespace PandaSharp.Bamboo.Services.Plan.Response.Converter
{
    internal sealed class ActionListResponseConverter : JsonListResponseConverterBase<ActionResponse>
    {
        protected override string ItemsPath => "action";
    }
}