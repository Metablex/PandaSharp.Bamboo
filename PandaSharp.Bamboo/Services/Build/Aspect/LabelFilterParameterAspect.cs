using System.Collections.Generic;
using PandaSharp.Bamboo.Services.Build.Contract;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Utils;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Build.Aspect
{
    internal sealed class LabelFilterParameterAspect : RequestParameterAspectBase, ILabelFilterParameterAspect
    {
        public IList<string> Labels { get; set; }

        public override void ApplyToRestRequest(IRestRequest restRequest)
        {
            restRequest.AddParameterValues("label", Labels);
        }
    }
}