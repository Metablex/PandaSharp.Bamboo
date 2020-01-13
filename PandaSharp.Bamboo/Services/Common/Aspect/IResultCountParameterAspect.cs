namespace PandaSharp.Bamboo.Services.Common.Aspect
{
    internal interface IResultCountParameterAspect
    {
        int? StartIndex { get; set; }

        int? MaxResults { get; set; }
    }
}