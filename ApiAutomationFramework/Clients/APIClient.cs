using RestSharp;
using System.Threading.Tasks;

public class ApiClient
{
    private readonly RestClient _client;

    public ApiClient(string baseUrl)
    {
        _client = new RestClient(baseUrl);
    }

    public async Task<RestResponse> ExecuteRequest(RestRequest request)
    {
        return await _client.ExecuteAsync(request);
    }
}