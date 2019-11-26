using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using PandaSharp.Attributes;
using PandaSharp.IoC.Contract;
using PandaSharp.IoC.Injections;

namespace PandaSharp.IoC.Factory
{
    internal abstract class InstanceFactoryBase : IInstanceFactory
    {
        private readonly Func<object> _factoryMethod;

        protected InstanceFactoryBase(Func<object> factoryMethod)
        {
            _factoryMethod = factoryMethod;
        }

        public abstract object CreateInstance(params InjectionBase[] injectedInformation);

        protected object ConstructObject(params InjectionBase[] injectedInformation)
        {
            var instance = _factoryMethod();

            InjectProperties(instance, injectedInformation);

            return instance;
        }

        private static void InjectProperties(object instance, IEnumerable<InjectionBase> injectedInformation)
        {
            var injectedProperties = injectedInformation
                .OfType<InjectProperty>()
                .ToDictionary(p => p.PropertyName, p => p.PropertyValue);

            if (!injectedProperties.Any())
            {
                return;
            }

            foreach (var instanceProperty in instance.GetType().GetProperties())
            {
                var attribute = instanceProperty.GetCustomAttribute<InjectedPropertyAttribute>();
                if (attribute != null)
                {
                    var propertyName = attribute.PropertyName ?? instanceProperty.Name;

                    if (injectedProperties.TryGetValue(propertyName, out var valueToInject))
                    {
                        instanceProperty.SetValue(instance, valueToInject);
                    }
                }
            }
        }
    }
}