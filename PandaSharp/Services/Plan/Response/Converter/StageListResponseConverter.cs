using PandaSharp.Services.Common.Response.Converter;

namespace PandaSharp.Services.Plan.Response.Converter
{
    internal sealed class StageListResponseConverter : JsonListResponseConverterBase<StageResponse>
    {
        protected override string ItemsPath => "stage";
    }
}