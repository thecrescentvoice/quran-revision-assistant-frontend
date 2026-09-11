using System.Threading.Tasks;

namespace Presentation.Services
{
    public class LocalApiClient : IPythonApiClient
    {
        public Task<ReviseResponse?> ReviseAsync(ReviseRequest request)
        {
            if (request == null) return Task.FromResult<ReviseResponse?>(null);
            var text = request.Text ?? string.Empty;
            var revised = text.ToUpperInvariant();
            var resp = new ReviseResponse { RevisedText = revised };
            return Task.FromResult<ReviseResponse?>(resp);
        }
    }
}
