using RestSharp.Deserializers;

namespace PandaSharp.Services.Build.Response
{
    public sealed class StageResponse
    {
        [DeserializeAs(Name = "name")]
        public string Name { get; set; }

        [DeserializeAs(Name = "state")]
        public string State { get; set; }

        [DeserializeAs(Name = "lifeCycleState")]
        public string LifeCycleSate { get; set; }

        [DeserializeAs(Name = "manual")]
        public bool IsManual { get; set; }

        [DeserializeAs(Name = "restartable")]
        public bool IsRestartable { get; set; }

        [DeserializeAs(Name = "runnable")]
        public bool IsRunnable { get; set; }
    }
}