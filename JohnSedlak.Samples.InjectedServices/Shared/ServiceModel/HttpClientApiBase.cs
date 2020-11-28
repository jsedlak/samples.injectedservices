using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace JohnSedlak.Samples.InjectedServices.ServiceModel
{
public abstract class HttpClientApiBase
{
    private readonly IJsonOptionsProvider _jsonOptionsProvider;

    public HttpClientApiBase(IHttpClientFactory httpClientFactory, IJsonOptionsProvider jsonOptionsProvider)
    {
        _jsonOptionsProvider = jsonOptionsProvider;
        ClientFactory = httpClientFactory;
    }

    protected async Task<TResult> DeleteAsync<TResult>(string path, string clientName = "api")
    {
        var client = ClientFactory.CreateClient(clientName);

        var result = await client.DeleteAsync(path);

        return await result.Content.ReadFromJsonAsync<TResult>(_jsonOptionsProvider.Options);
    }

    protected async Task<TResult> PutAsync<TModel, TResult>(string path, TModel model, string clientName = "api")
    {
        var client = ClientFactory.CreateClient(clientName);

        var result = await client.PutAsJsonAsync<TModel>(
            path,
            model,
            _jsonOptionsProvider.Options
        );

        return await result.Content.ReadFromJsonAsync<TResult>(_jsonOptionsProvider.Options);
    }

    protected async Task<TResult> PostAsync<TModel, TResult>(string path, TModel model, string clientName = "api")
    {
        var client = ClientFactory.CreateClient(clientName);

        var result = await client.PostAsJsonAsync<TModel>(
            path,
            model,
            _jsonOptionsProvider.Options
        );

        return await result.Content.ReadFromJsonAsync<TResult>(_jsonOptionsProvider.Options);
    }

    protected async Task<TResult> GetAsync<TResult>(string path, string clientName = "api")
    {
        var client = ClientFactory.CreateClient(clientName);

        var result = await client.GetFromJsonAsync<TResult>(
            path,
            _jsonOptionsProvider.Options
        );

        return result;
    }

    protected IHttpClientFactory ClientFactory { get; private set; }
}
}

