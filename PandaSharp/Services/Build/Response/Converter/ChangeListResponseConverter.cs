using PandaSharp.Services.Common.Response.Converter;

namespace PandaSharp.Services.Build.Response.Converter
{
    internal sealed class ChangeListResponseConverter : JsonListResponseConverterBase<ChangeResponse>
    {
        protected override string ItemsPath => "change";
    }
}