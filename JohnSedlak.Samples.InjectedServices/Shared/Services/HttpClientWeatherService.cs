using JohnSedlak.Samples.InjectedServices.ServiceModel;
using JohnSedlak.Samples.InjectedServices.ViewModel;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace JohnSedlak.Samples.InjectedServices.Services
{
    public sealed class HttpClientWeatherService : HttpClientApiBase, IWeatherService
    {
        public HttpClientWeatherService(IHttpClientFactory httpClientFactory, IJsonOptionsProvider jsonOptionsProvider)
            : base(httpClientFactory, jsonOptionsProvider)
        {

        }

        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            return await GetAsync<IEnumerable<WeatherForecast>>("/api/weatherforecast");
        }
    }
}
