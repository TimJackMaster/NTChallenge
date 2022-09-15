using RestSharp;

namespace Application.Requests;

internal class RestClientWrapper : IRestClient
{
    public async Task<RestResponse> GetAsync(RestRequest request, Uri uri)
    {
        var client = new RestClient(uri);
        var result = await client.GetAsync(request);

        return result;
    }
}
