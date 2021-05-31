using System.Collections.Generic;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Utils;
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