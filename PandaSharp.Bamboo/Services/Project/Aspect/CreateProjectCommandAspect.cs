using Newtonsoft.Json.Linq;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Utils;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Project.Aspect
{
    internal sealed class CreateProjectCommandAspect : RequestParameterAspectBase, ICreateProjectCommandAspect
    {
        private string _projectKey;
        private string _projectName;
        private string _description;
        private bool _enablePublicAccess;

        public void SetProjectKey(string projectKey)
        {
            _projectKey = projectKey;
        }

        public void SetProjectName(string projectName)
        {
            _projectName = projectName;
        }

        public void SetDescription(string description)
        {
            _description = description;
        }

        public void EnablePublicAccess(bool enablePublicAccess)
        {
            _enablePublicAccess = enablePublicAccess;
        }

        public override void ApplyToRestRequest(IRestRequest restRequest)
        {
            var json = new JObject
            {
                { "key", _projectKey },
                { "name", _projectName },
                { "publicAccess", _enablePublicAccess }
            };

            if (!_description.IsNullOrEmpty())
            {
                json.Add("description", _description);
            }

            restRequest.AddJsonBody(json);
        }
    }
}