namespace PandaSharp.Bamboo.Services.Common.Aspect
{
    internal interface IResultCountParameterAspect
    {
        void SetStartIndex(int startIndex);
        
        void SetMaxResults(int maxResults);
    }
}