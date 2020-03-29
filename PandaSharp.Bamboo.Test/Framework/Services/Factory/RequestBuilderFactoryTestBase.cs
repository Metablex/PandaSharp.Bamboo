using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.IoC.Contract;
using PandaSharp.Bamboo.IoC.Injections;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Framework.Services.Factory
{
    internal class RequestBuilderFactoryTestBase
    {
        protected Mock<IPandaContainer> Container { get; private set; }

        [SetUp]
        public void BeforeEachTest()
        {
            Container = new Mock<IPandaContainer>();
        }

        protected void ShouldContainInjectionProperty(IEnumerable<InjectionBase> injectedInfos, string propertyName, object value)
        {
            injectedInfos
                .OfType<InjectProperty>()
                .ShouldContain(p => p.PropertyName == propertyName && p.PropertyValue.Equals(value));
        }

        protected void SetupRequestRegistration<T>(Action<InjectionBase[]> validateInjectedParts)
            where T : class
        {
            Container
                .Setup(i => i.Resolve<T>(It.IsAny<InjectionBase[]>()))
                .Callback(validateInjectedParts)
                .Returns(new Mock<T>().Object)
                .Verifiable();
        }
    }
}