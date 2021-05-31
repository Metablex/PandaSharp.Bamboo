using PandaSharp.Framework.Attributes;

namespace PandaSharp.Bamboo.Services.Build.Types
{
    internal enum BuildState
    {
        [StringRepresentation("unknown")]
        Unknown,

        [StringRepresentation("failed")]
        Failed,

        [StringRepresentation("successful")]
        Successful
    }
}