using System;

namespace PandaSharp.Bamboo.Attributes
{
    internal sealed class JsonRootElementPathAttribute : Attribute
    {
        public string RootElementPath { get; }

        public JsonRootElementPathAttribute(string rootElementPath)
        {
            RootElementPath = rootElementPath;
        }
    }
}