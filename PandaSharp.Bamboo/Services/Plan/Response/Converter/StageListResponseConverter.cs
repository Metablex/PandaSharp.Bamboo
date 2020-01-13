using PandaSharp.Bamboo.Services.Common.Response.Converter;

namespace PandaSharp.Bamboo.Services.Plan.Response.Converter
{
    internal sealed class StageListResponseConverter : JsonListResponseConverterBase<StageResponse>
    {
        protected override string ItemsPath => "stage";
    }
}