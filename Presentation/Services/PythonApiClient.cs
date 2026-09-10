using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Presentation.Services
{
    public class ReviseRequest { public string Text { get; set; } = string.Empty; }
    public class ReviseResponse { public string RevisedText { get; set; } = string.Empty; }

    public interface IPythonApiClient
    {
        Task<ReviseResponse?> ReviseAsync(ReviseRequest request);
    }

    public class PythonApiClient : IPythonApiClient
    {
        private readonly HttpClient _http;
        public PythonApiClient(HttpClient http) => _http = http;

        public async Task<ReviseResponse?> ReviseAsync(ReviseRequest request)
        {
            var resp = await _http.PostAsJsonAsync("/revise", request);
            if (!resp.IsSuccessStatusCode) return null;
            return await resp.Content.ReadFromJsonAsync<ReviseResponse?>();
        }
    }
}
