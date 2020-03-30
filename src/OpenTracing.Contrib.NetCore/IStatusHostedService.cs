using Microsoft.Extensions.Hosting;

namespace OpenTracing.Contrib.NetCore
{
    public interface IStatusHostedService : IHostedService
    {
        HostedServiceStatus Status { get; }
    }
}
