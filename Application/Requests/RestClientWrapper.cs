using RestSharp;

namespace Application.Requests;

internal sealed class RestClient : IRestClient
{
    public async Task<RestResponse> GetAsync(RestRequest request, Uri uri)
    {
        var client = new RestSharp.RestClient(uri);
        var result = await client.GetAsync(request);

        return result;
    }
}
