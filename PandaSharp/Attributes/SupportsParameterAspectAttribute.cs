using System;

namespace PandaSharp.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    internal sealed class SupportsParameterAspectAttribute : Attribute
    {
        public Type ParameterAspectType { get; }

        public SupportsParameterAspectAttribute(Type parameterAspectType)
        {
            ParameterAspectType = parameterAspectType;
        }
    }
}