using System;
using System.Collections.Generic;
using System.Linq;
using PandaSharp.IoC;
using PandaSharp.IoC.Contract;
using PandaSharp.Services.Common.Contract;

namespace PandaSharp.Services.Common.Request
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
            _latestRequestType = typeof(TInstance);
            return this;
        }

        public void Register(PandaContainerContext context)
        {
            var versionSpecificRequestType = _versionSpecificRequestTypes
                .Where(types => types.VersionUpTo >= context.CurrentBambooVersion)
                .OrderBy(types => types.VersionUpTo)
                .FirstOrDefault();

            var requestTypeToRegister = versionSpecificRequestType != null
                ? versionSpecificRequestType.RequestType
                : _latestRequestType;

            _container.RegisterType<T>(requestTypeToRegister);
        }

        private class VersionSpecificRequestType
        {
            public Version VersionUpTo { get; set; }

            public Type RequestType { get; set; }
        }
    }
}