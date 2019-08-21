namespace PandaSharp.Services.Plan.Contract
{
    public interface IAllPlansRequest
    {
        IAllPlansRequest WithMaxResult(int maxResult);

        IAllPlansRequest StartAtIndex(int startIndex);

        IAllPlansRequest IncludeDetails();

        IAllPlansRequest IncludeDetailsAndActions();

        IAllPlansResponse Execute();
    }
}
