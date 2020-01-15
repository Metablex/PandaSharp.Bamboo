using System;

namespace PandaSharp.Bamboo.Attributes
{
    internal sealed class JsonItemsAttribute : Attribute
    {
        public string ItemsPath { get; }

        public JsonItemsAttribute(string itemsPath)
        {
            ItemsPath = itemsPath;
        }
    }
}