using JohnSedlak.Samples.InjectedServices.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JohnSedlak.Samples.InjectedServices.ServiceModel
{
    public interface IWeatherService
    {
        Task<IEnumerable<WeatherForecast>> Get();
    }
}
