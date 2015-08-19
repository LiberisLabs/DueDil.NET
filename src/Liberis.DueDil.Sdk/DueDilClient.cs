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
    public class DueDilClient
    {
        private readonly DueDilClientSettings _settings;
        private readonly SearchCompaniesUriBuilder _searchCompaniesUriBuilder;

        public DueDilClient(DueDilClientSettings settings, SearchCompaniesUriBuilder searchCompaniesUriBuilder)
        {
            _settings = settings;
            _searchCompaniesUriBuilder = searchCompaniesUriBuilder;
        }

        public DueDilClient(DueDilClientSettings settings)
            : this(settings, new SearchCompaniesUriBuilder(settings.BaseUri, settings.ApiKey))
        {
            
        }

        public async Task<DueDilClientResponse<DueDilResponse<PaginatedResponse<SearchCompanyResult>>>> SearchCompanies(Terms terms)
        {
            var httpClient = CreateHttpClient(_settings);

            var response = await httpClient.GetAsync(_searchCompaniesUriBuilder.BuildUri(terms))
                                                .ConfigureAwait(false);

            var dueDilResponse = new DueDilClientResponse<DueDilResponse<PaginatedResponse<SearchCompanyResult>>>();

            if (response.IsSuccessStatusCode)
            {
                dueDilResponse.IsOk = true;
                dueDilResponse.Data = await response.Content.ReadAsAsync<DueDilResponse<PaginatedResponse<SearchCompanyResult>>>()
                                                                .ConfigureAwait(false);
            }

            return dueDilResponse;
        }
        
        private HttpClient CreateHttpClient(DueDilClientSettings settings)
        {
            var handlers = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            var httpClient = HttpClientFactory.Create(handlers);

            httpClient.BaseAddress = settings.BaseUri;

            return httpClient;
        }
    }

    public class DueDilClientSettings
    {
        private readonly string _apiKey;
        private readonly Uri _baseUri;

        public DueDilClientSettings(Uri baseUri, string apiKey)
        {
            _baseUri = baseUri;
            _apiKey = apiKey;
        }

        public Uri BaseUri
        {
            get { return _baseUri; }
        }

        public string ApiKey
        {
            get { return _apiKey; }
        }
    }
}
