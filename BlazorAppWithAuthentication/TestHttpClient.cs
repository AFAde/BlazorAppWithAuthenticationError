using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorAppWithAuthentication
{
    public class TestHttpClient : IDisposable
    {
        private readonly HttpClient _httpClient;

        public TestHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task SendRequestAsync()
        {
            await _httpClient.GetAsync("http://localhost").ConfigureAwait(false);
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}
