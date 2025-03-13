using PandaSharp.Framework.Services.Aspect;

namespace PandaSharp.Bamboo.Services.Common.Aspect
{
    internal interface IResultCountParameterAspect : IRequestParameterAspect
    {
        void SetStartIndex(int startIndex);

        void SetMaxResults(int maxResults);
    }
}
