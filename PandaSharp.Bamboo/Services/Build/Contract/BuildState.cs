using PandaSharp.Bamboo.Attributes;

namespace PandaSharp.Bamboo.Services.Build.Contract
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