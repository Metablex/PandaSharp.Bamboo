using System.IO;
using NUnit.Framework;
using PandaSharp.Utils;

namespace PandaSharp.Test
{
    [TestFixture]
    public class BamboConnectionTest
    {
        [Test]
        public void Test()
        {
            var api = new BambooApi("https://bamboo.qoniac.com", TestConstants.UserName, TestConstants.Password);

            var request = api
                .BuildRequest
                .InformationOfLatestBuild("O56", "CORE8")
                .IncludingMetaData();

            var json = request.DownloadData();
            File.WriteAllText(@"C:\Users\tom.birras\Downloads\PandaSharpData\allplans.json", json);

            var response = request.Execute();
        }
    }
}