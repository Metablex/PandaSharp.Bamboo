using System;

namespace PandaSharp.Bamboo.IoC.Contract
{
    internal interface IRequestProviderRegistration<in T>
    {
        IRequestProviderRegistration<T> VersionSpecificRequest<TInstance>(Version version)
            where TInstance : T;

        IRequestProviderRegistration<T> LatestRequest<TInstance>()
            where TInstance : T;

        void Register(PandaContainerContext context);
    }
}