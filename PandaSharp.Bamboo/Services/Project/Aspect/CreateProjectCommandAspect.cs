using Newtonsoft.Json.Linq;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Utils;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Project.Aspect
{
    internal sealed class CreateProjectCommandAspect : RequestParameterAspectBase, ICreateProjectCommandAspect
    {
        public string ProjectKey { get; set; }

        public string ProjectName { get; set; }

        public string Description { get; set; }

        public bool EnablePublicAccess { get; set; }

        public override void ApplyToRestRequest(IRestRequest restRequest)
        {
            var json = new JObject
            {
                { "key", ProjectKey },
                { "name", ProjectName },
                { "publicAccess", EnablePublicAccess }
            };

            if (!Description.IsNullOrEmpty())
            {
                json.Add("description", Description);
            }

            restRequest.AddJsonBody(json);
        }
    }
}