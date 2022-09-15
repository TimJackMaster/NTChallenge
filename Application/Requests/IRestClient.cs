using RestSharp;

namespace Application.Requests;

internal interface IRestClient
{
    public Task<RestResponse> GetAsync(RestRequest request, Uri uri);
}
