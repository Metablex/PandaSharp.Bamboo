namespace PandaSharp.Bamboo.Services.Common.Contract
{
    public interface IRequestBase<out T>
    {
        T Execute();
    }
}
