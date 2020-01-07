using System;

namespace PandaSharp.IoC
{
    internal sealed class PandaContainerContext
    {
        public Version CurrentBambooVersion { get; }

        public PandaContainerContext(Version currentBambooVersion)
        {
            CurrentBambooVersion = currentBambooVersion;
        }
    }
}