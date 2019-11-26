using System;
using PandaSharp.IoC.Injections;

namespace PandaSharp.IoC.Factory
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
            return _instance ?? (_instance = ConstructObject(injectedInformation));
        }
    }
}