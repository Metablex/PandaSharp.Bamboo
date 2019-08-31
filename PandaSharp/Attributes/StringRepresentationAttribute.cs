using System;

namespace PandaSharp.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    internal class StringRepresentationAttribute : Attribute
    {
        public string AsString { get; }

        public StringRepresentationAttribute(string stringRepresentation)
        {
            AsString = stringRepresentation;
        }
    }
}
