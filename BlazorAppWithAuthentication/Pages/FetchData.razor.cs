using BlazorAppWithAuthentication.Data;
using System.Threading.Tasks;
using System;

namespace BlazorAppWithAuthentication.Pages
{
    public partial class FetchData : CustomComponentBase
    {
        private WeatherForecast[] forecasts;

        protected override async Task OnInitializedAsync() { await GetData(); }

        private async Task GetData()
        {
            forecasts = null;
            forecasts = await ForecastService.GetForecastAsync(DateTime.Now);
        }
    }
}
