using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAppWithAuthentication.Data
{
    public class WeatherForecastService
    {
        private readonly TestHttpClient _testHttpClient;

        public WeatherForecastService(TestHttpClient testHttpClient)
        {
            _testHttpClient = testHttpClient;
        }
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public async Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            //this will throw the exception "GetAuthenticationStateAsync was called before SetAuthenticationState"
            await _testHttpClient.SendRequestAsync().ConfigureAwait(false);
            var rng = new Random();
            return await Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray());
        }
    }
}
