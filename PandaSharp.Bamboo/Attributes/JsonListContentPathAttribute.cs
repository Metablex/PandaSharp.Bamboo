using System;

namespace PandaSharp.Bamboo.Attributes
{
    internal sealed class JsonListContentPathAttribute : Attribute
    {
        public string ListContentPath { get; }

        public JsonListContentPathAttribute(string listContentPath)
        {
            ListContentPath = listContentPath;
        }
    }
}