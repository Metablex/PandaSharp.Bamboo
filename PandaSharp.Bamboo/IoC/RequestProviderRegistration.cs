using System;
using System.Collections.Generic;
using System.Linq;
using PandaSharp.Bamboo.IoC.Contract;

namespace PandaSharp.Bamboo.IoC
{
    internal sealed class RequestProviderRegistration<T> : IRequestProviderRegistration<T>
    {
        private readonly IPandaContainer _container;
        private readonly List<VersionSpecificRequestType> _versionSpecificRequestTypes;
        private Type _latestRequestType;

        public RequestProviderRegistration(IPandaContainer container)
        {
            _container = container;
            _versionSpecificRequestTypes = new List<VersionSpecificRequestType>();
        }

        public IRequestProviderRegistration<T> VersionSpecificRequest<TInstance>(Version version)
            where TInstance : T
        {
            _versionSpecificRequestTypes.Add(
                new VersionSpecificRequestType
                {
                    VersionUpTo = version,
                    RequestType = typeof(TInstance)
                });

            return this;
        }

        public IRequestProviderRegistration<T> LatestRequest<TInstance>()
            where TInstance : T
        {
            if (_latestRequestType != null)
            {
                throw new InvalidOperationException($"Type of latest request for {typeof(T).Name} was already specified");
            }

            _latestRequestType = typeof(TInstance);
            return this;
        }

        public void Register(PandaContainerContext context)
        {
            var versionSpecificRequestType = GetVersionSpecificRequestType(context);

            var requestTypeToRegister = versionSpecificRequestType != null
                ? versionSpecificRequestType.RequestType
                : _latestRequestType;

            _container.RegisterType<T>(requestTypeToRegister);
        }

        private VersionSpecificRequestType GetVersionSpecificRequestType(PandaContainerContext context)
        {
            if (context.CurrentBambooVersion == null)
            {
                return null;
            }

            return _versionSpecificRequestTypes
                .Where(types => types.VersionUpTo >= context.CurrentBambooVersion)
                .OrderBy(types => types.VersionUpTo)
                .FirstOrDefault();
        }

        private class VersionSpecificRequestType
        {
            public Version VersionUpTo { get; set; }

            public Type RequestType { get; set; }
        }
    }
}