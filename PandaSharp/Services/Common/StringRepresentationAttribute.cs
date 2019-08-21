using System;

namespace PandaSharp.Services.Common
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    internal class StringRepresentationAttribute : Attribute
    {
        public string AsString { get; }

        public StringRepresentationAttribute(string stringRepresentation)
        {
            AsString = stringRepresentation;
        }
    }
}
