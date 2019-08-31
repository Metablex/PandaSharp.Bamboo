namespace PandaSharp.Services.Common.Contract
{
    internal interface IExpandStateParameterAspectBase<T>
    {
        T ExpandState { get; set; }
    }
}