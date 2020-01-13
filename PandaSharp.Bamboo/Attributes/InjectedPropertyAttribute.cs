using System;

namespace PandaSharp.Bamboo.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class InjectedPropertyAttribute : Attribute
    {
        public string PropertyName { get; }

        public InjectedPropertyAttribute(string propertyName = null)
        {
            PropertyName = propertyName;
        }
    }
}