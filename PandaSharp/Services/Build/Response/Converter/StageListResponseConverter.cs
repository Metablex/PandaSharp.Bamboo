using PandaSharp.Services.Common.Response.Converter;

namespace PandaSharp.Services.Build.Response.Converter
{
    internal sealed class StageListResponseConverter : JsonListResponseConverterBase<StageResponse>
    {
        protected override string ItemsPath => "stage";
    }
}