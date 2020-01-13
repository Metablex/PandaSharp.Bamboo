using PandaSharp.Bamboo.IoC.Injections;

namespace PandaSharp.Bamboo.IoC.Contract
{
    internal interface IInstanceFactory
    {
        object CreateInstance(params InjectionBase[] injectedInformation);
    }
}