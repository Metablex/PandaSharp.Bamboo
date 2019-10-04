using PandaSharp.Attributes;

namespace PandaSharp.Services.Build.Contract
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