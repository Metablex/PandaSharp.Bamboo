using System;
using PandaSharp.Bamboo.Services.Common.Request;

namespace PandaSharp.Bamboo.IoC.Contract
{
    internal interface IRequestProviderRegistration<in T>
    {
        IRequestProviderRegistration<T> VersionSpecificRequest<TInstance>(Version version)
            where TInstance : T;

        IRequestProviderRegistration<T> LatestRequest<TInstance>()
            where TInstance : RestCommunicationBase, T;

        void Register(PandaContainerContext context);
    }
}