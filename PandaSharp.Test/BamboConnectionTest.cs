using NUnit.Framework;
using PandaSharp;

namespace Tests
{
    [TestFixture]
    public class BamboConnectionTest
    {
        [Test]
        public void Test()
        {
            var api = new BambooApi("http://qoniac.bamboo.com", "user", "password");
        }
    }
}