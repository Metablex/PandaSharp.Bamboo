using System;
using PandaSharp.IoC.Injections;

namespace PandaSharp.IoC.Contract
{
    internal interface IPandaContainer
    {
        void RegisterType<T, TInstance>() where TInstance : T;

        void RegisterType<T>(Func<T> customFactoryMethod);

        void RegisterSingletonType<T, TInstance>() where TInstance : T;

        void RegisterSingletonType<T>(Func<T> customFactoryMethod);

        T Resolve<T>(params InjectionBase[] injectedInformation);

        object Resolve(Type type, params InjectionBase[] injectedInformation);
    }
}