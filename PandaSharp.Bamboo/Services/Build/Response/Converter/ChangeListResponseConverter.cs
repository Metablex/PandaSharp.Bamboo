using PandaSharp.Bamboo.Services.Common.Response.Converter;

namespace PandaSharp.Bamboo.Services.Build.Response.Converter
{
    internal sealed class ChangeListResponseConverter : JsonListResponseConverterBase<ChangeResponse>
    {
        protected override string ItemsPath => "change";
    }
}