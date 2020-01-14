using System;

namespace PandaSharp.Bamboo.Attributes
{
    internal sealed class JsonItems : Attribute
    {
        public string ItemsPath { get; }

        public JsonItems(string itemsPath)
        {
            ItemsPath = itemsPath;
        }
    }
}