using System.Text.Json;

namespace JohnSedlak.Samples.InjectedServices.ServiceModel
{
    public interface IJsonOptionsProvider
    {
        JsonSerializerOptions Options { get; }
    }
}

