using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using PandaSharp.Attributes;
using PandaSharp.Services.Common.Contract;
using Unity;

namespace PandaSharp.Services.Common.Aspect
{
    internal sealed class RequestParameterAspectFactory : IRequestParameterAspectFactory
    {
        private readonly IUnityContainer _container;

        public RequestParameterAspectFactory(IUnityContainer container)
        {
            _container = container;
        }

        public IList<IRequestParameterAspect> GetParameterAspects(Type type)
        {
            return type
                .GetCustomAttributes(typeof(SupportsParameterAspectAttribute))
                .Cast<SupportsParameterAspectAttribute>()
                .Select(attribute => _container.Resolve(attribute.ParameterAspectType))
                .OfType<IRequestParameterAspect>()
                .ToList();
        }
    }
}