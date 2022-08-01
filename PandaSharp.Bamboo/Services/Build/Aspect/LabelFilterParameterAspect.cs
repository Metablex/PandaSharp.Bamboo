using System.Collections.Generic;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Utils;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Build.Aspect
{
    internal sealed class LabelFilterParameterAspect : RequestParameterAspectBase, ILabelFilterParameterAspect
    {
        private IList<string> _labels;

        public void SetLabelsFilter(IList<string> labels)
        {
            _labels = labels;
        }

        public override void ApplyToRestRequest(IRestRequest restRequest)
        {
            restRequest.AddParameterValues("label", _labels);
        }
    }
}