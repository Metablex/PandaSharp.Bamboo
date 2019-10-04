using System.Collections.Generic;
using PandaSharp.Services.Build.Contract;
using PandaSharp.Services.Common.Aspect;
using PandaSharp.Utils;
using RestSharp;

namespace PandaSharp.Services.Build.Aspect
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