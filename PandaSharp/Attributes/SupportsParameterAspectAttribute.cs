using System;

namespace PandaSharp.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    internal sealed class SupportsParameterAspectAttribute : Attribute
    {
        public string ParameterAspectName { get; }

        public SupportsParameterAspectAttribute(string parameterAspectName)
        {
            ParameterAspectName = parameterAspectName;
        }
    }
}