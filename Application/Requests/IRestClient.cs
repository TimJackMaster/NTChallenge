using RestSharp;

namespace Application.Requests;

/// <summary>
/// Interface to encapsulate the RestClient for test purposes.
/// </summary>
public interface IRestClient
{
    public Task<RestResponse> GetAsync(RestRequest request, Uri uri);
}
