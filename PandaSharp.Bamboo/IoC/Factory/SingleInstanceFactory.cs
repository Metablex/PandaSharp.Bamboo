using System;
using PandaSharp.Bamboo.IoC.Injections;

namespace PandaSharp.Bamboo.IoC.Factory
{
    internal class SingleInstanceFactory : InstanceFactoryBase
    {
        private object _instance;

        public SingleInstanceFactory(Func<object> factoryMethod)
            : base(factoryMethod)
        {
        }

        public override object CreateInstance(params InjectionBase[] injectedInformation)
        {
            return _instance ??= ConstructObject(injectedInformation);
        }
    }
}