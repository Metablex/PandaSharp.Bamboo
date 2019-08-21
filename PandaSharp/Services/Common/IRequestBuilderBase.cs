using RestSharp;

namespace PandaSharp.Services.Common
{
    public interface IRequestBuilderBase<T>
    {
        IRestRequest Build();
    }
}
