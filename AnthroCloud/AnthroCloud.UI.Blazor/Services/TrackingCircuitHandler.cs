using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Server.Circuits;

namespace AnthroCloud.UI.Blazor.Services
{
    public class TrackingCircuitHandler : CircuitHandler
    {
        private HashSet<Circuit> circuits = new();

        public override Task OnConnectionUpAsync(Circuit circuit,
            CancellationToken cancellationToken)
        {
            circuits.Add(circuit);

            return Task.CompletedTask;
        }

        public override Task OnConnectionDownAsync(Circuit circuit,
            CancellationToken cancellationToken)
        {
            circuits.Remove(circuit);

            return Task.CompletedTask;
        }

        public int ConnectedCircuits => circuits.Count;
    }
}