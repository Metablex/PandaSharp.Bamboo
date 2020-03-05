using NUnit.Framework;
using PandaSharp.Bamboo.Rest.Common;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Rest.Common
{
    [TestFixture]
    public sealed class BambooOptionsTest
    {
        private const string BambooTestAddress = "http://test.bamboo.com/rest/api/latest";

        [Test]
        public void BaseUrlAdjustementTest()
        {
            var options = new BambooOptions();
            options.BaseUrl.ShouldBeNull();

            options.BaseUrl = BambooTestAddress;
            options.BaseUrl.ShouldBe(BambooTestAddress);

            options.BaseUrl = "http://test.bamboo.com";
            options.BaseUrl.ShouldBe(BambooTestAddress);
        }

        [Test]
        public void BasePropertyTest()
        {
            var options = new BambooOptions();
            options.Password = "PasswordTest";
            options.UserName = "UserTest";

            options.Password.ShouldBe("PasswordTest");
            options.UserName.ShouldBe("UserTest");
        }
    }
}