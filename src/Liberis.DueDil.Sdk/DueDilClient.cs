using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Liberis.DueDil.Sdk.Requests.SearchCompanies;
using Liberis.DueDil.Sdk.Responses;
using Liberis.DueDil.Sdk.Responses.SearchCompanies;
using Liberis.DueDil.Sdk.UriBuilders;

namespace Liberis.DueDil.Sdk
{
    public class DueDilClient : IDueDilClient
    {
        private readonly Uri _baseUri;
        private readonly ISearchCompaniesUriBuilder _searchCompaniesUriBuilder;

        public DueDilClient(Uri baseUri, ISearchCompaniesUriBuilder searchCompaniesUriBuilder)
        {
            _baseUri = baseUri;
            _searchCompaniesUriBuilder = searchCompaniesUriBuilder;
        }

        public async Task<DueDilClientResponse<DueDilResponse<PaginatedResponse<SearchCompanyResult>>>> SearchCompanies(Terms terms)
        {
            var httpClient = CreateHttpClient();

            var response = await httpClient.GetAsync(_searchCompaniesUriBuilder.BuildUri(terms))
                                                .ConfigureAwait(false);

            var dueDilResponse = new DueDilClientResponse<DueDilResponse<PaginatedResponse<SearchCompanyResult>>>();

            response.EnsureSuccessStatusCode();

            dueDilResponse.Data = await response.Content.ReadAsAsync<DueDilResponse<PaginatedResponse<SearchCompanyResult>>>()
                                                                .ConfigureAwait(false);

            return dueDilResponse;
        }
        
        private HttpClient CreateHttpClient()
        {
            var handlers = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            var httpClient = HttpClientFactory.Create(handlers);

            httpClient.BaseAddress = _baseUri;
            
            return httpClient;
        }
    }
}
