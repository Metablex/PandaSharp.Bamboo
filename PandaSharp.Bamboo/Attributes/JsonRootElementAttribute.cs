using System;

namespace PandaSharp.Bamboo.Attributes
{
    internal sealed class JsonRootElementAttribute : Attribute
    {
        public string RootElement { get; }

        public JsonRootElementAttribute(string rootElement)
        {
            RootElement = rootElement;
        }
    }
}