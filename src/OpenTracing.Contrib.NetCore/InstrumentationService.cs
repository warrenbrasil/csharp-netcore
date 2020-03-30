using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using OpenTracing.Contrib.NetCore.Internal;

namespace OpenTracing.Contrib.NetCore
{
    /// <summary>
    /// Starts and stops all OpenTracing instrumentation components.
    /// </summary>
    internal class InstrumentationService : IStatusHostedService
    {
        private readonly DiagnosticManager _diagnosticsManager;

        public HostedServiceStatus Status { get; private set; }

        public InstrumentationService(DiagnosticManager diagnosticManager)
        {
            _diagnosticsManager = diagnosticManager ?? throw new ArgumentNullException(nameof(diagnosticManager));

            Status = HostedServiceStatus.Created;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _diagnosticsManager.Start();

            Status = HostedServiceStatus.Started;

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _diagnosticsManager.Stop();

            Status = HostedServiceStatus.Stopped;

            return Task.CompletedTask;
        }
    }
}
