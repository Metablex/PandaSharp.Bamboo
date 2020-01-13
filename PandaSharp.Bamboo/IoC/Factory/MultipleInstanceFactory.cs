using System;
using PandaSharp.Bamboo.IoC.Injections;

namespace PandaSharp.Bamboo.IoC.Factory
{
    internal class MultipleInstanceFactory : InstanceFactoryBase
    {
        public MultipleInstanceFactory(Func<object> factoryMethod)
            : base(factoryMethod)
        {
        }

        public override object CreateInstance(params InjectionBase[] injectedInformation)
        {
            return ConstructObject(injectedInformation);
        }
    }
}