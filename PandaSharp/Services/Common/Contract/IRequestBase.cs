using RestSharp;

namespace PandaSharp.Services.Common.Contract
{
    public interface IRequestBase<T>
    {
        IRestRequest Build();
    }
}
