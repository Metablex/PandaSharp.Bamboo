using System;
using Newtonsoft.Json.Linq;
using PandaSharp.Framework.IoC.Contract;
using PandaSharp.Framework.Rest.Contract;
using RestSharp;

namespace PandaSharp.Bamboo
{
    internal sealed class BambooApiContext : IPandaContainerContext
    {
        private Version _currentBambooVersion;

        public Version GetCurrentApiVersion(IPandaContainer container)
        {
            if (_currentBambooVersion == null)
            {
                _currentBambooVersion = LoadCurrentBambooVersion(container);
            }

            return _currentBambooVersion;
        }

        private static Version LoadCurrentBambooVersion(IPandaContainer container)
        {
            var restFactory = container.Resolve<IRestFactory>();
            var restClient = restFactory.CreateClient();
            var restRequest = restFactory.CreateRequest("info", Method.GET);

            try
            {
                var infoResponse = restClient.Execute(restRequest);
                var jsonResponse = JObject.Parse(infoResponse.Content);
                var version = (string)jsonResponse.SelectToken("version");

                return new Version(version!);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}