using NUnit.Framework;
using PandaSharp.Bamboo.Services.Search.Contract;
using PandaSharp.Bamboo.Services.Search.Factory;
using PandaSharp.Bamboo.Test.Framework.Services.Factory;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Search.Factory
{
    [TestFixture]
    internal sealed class SearchRequestBuilderFactoryTest 
    {
        [Test]
        public void SearchForPlansTest()
        {
            var containerMock = RequestBuilderFactoryMockBuilder.CreateRequestRegistrationMock<ISearchForPlansRequest>(parameters => parameters.ShouldBeEmpty());

            var factory = new SearchRequestBuilderFactory(containerMock.Object);
            var request = factory.SearchForPlans();

            request.ShouldNotBeNull();

            containerMock.Verify();
            containerMock.VerifyNoOtherCalls();
        }
    }
}