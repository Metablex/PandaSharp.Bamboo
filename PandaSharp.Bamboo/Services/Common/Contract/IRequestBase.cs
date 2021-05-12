using System;
using System.Threading;
using System.Threading.Tasks;

namespace PandaSharp.Bamboo.Services.Common.Contract
{
    public interface IRequestBase<T>
    {
        Task<T> ExecuteAsync(CancellationToken cancellationToken);

        Task<T> ExecuteAsync();

        Uri GetRequestUri();
    }
}
