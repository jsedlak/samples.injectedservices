using JohnSedlak.Samples.InjectedServices.ServiceModel;
using System.Text.Json;

namespace JohnSedlak.Samples.InjectedServices.Services
{
    public sealed class StaticJsonOptionsProvider : IJsonOptionsProvider
    {
        public JsonSerializerOptions Options => new JsonSerializerOptions() { WriteIndented = true };
    }
}
