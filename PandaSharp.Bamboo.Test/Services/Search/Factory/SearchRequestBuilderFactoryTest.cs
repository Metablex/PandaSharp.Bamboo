using NUnit.Framework;
using PandaSharp.Bamboo.Services.Search.Contract;
using PandaSharp.Bamboo.Services.Search.Factory;
using PandaSharp.Bamboo.Test.Framework.Services.Factory;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Search.Factory
{
    [TestFixture]
    internal sealed class SearchRequestBuilderFactoryTest : RequestBuilderFactoryTestBase
    {
        [Test]
        public void ForPlansTest()
        {
            SetupRequestRegistration<IPlanSearchRequest>(parameters => parameters.ShouldBeEmpty());

            var factory = new SearchRequestBuilderFactory(Container.Object);
            var request = factory.ForPlans();

            request.ShouldNotBeNull();

            Container.Verify();
            Container.VerifyNoOtherCalls();
        }
    }
}