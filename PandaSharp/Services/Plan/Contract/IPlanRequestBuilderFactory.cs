namespace PandaSharp.Services.Plan.Contract
{
    public interface IPlanRequestBuilderFactory
    {
        IAllPlansRequest AllPlans();

        IInformationOfRequest InformationOf(string projectKey, string planKey);
    }
}
