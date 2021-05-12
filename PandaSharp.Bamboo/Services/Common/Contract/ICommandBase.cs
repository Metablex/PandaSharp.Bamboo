using System;
using System.Threading;
using System.Threading.Tasks;

namespace PandaSharp.Bamboo.Services.Common.Contract
{
    public interface ICommandBase
    {
        Task ExecuteAsync(CancellationToken cancellationToken);

        Task ExecuteAsync();

        Uri GetCommandUri();
    }
}