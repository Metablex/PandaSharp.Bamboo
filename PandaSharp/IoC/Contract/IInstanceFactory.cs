using PandaSharp.IoC.Injections;

namespace PandaSharp.IoC.Contract
{
    internal interface IInstanceFactory
    {
        object CreateInstance(params InjectionBase[] injectedInformation);
    }
}