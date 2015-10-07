using System;
using System.CodeDom;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using LiberisLabs.DueDil.Requests.SearchCompanies;
using LiberisLabs.DueDil.Responses;
using LiberisLabs.DueDil.Responses.Companies;
using LiberisLabs.DueDil.Responses.SearchCompanies;
using LiberisLabs.DueDil.UriBuilders;

namespace LiberisLabs.DueDil
{
    public class DueDilClient : IDueDilClient
    {
        private readonly Uri _baseUri;
        private readonly ISearchCompaniesUriBuilder _searchCompaniesUriBuilder;
        private readonly IGetCompanyUriBuilder _getCompanyUriBuilder;

        public DueDilClient(Uri baseUri, ISearchCompaniesUriBuilder searchCompaniesUriBuilder, IGetCompanyUriBuilder getCompanyUriBuilder)
        {
            _baseUri = baseUri;
            _searchCompaniesUriBuilder = searchCompaniesUriBuilder;
            _getCompanyUriBuilder = getCompanyUriBuilder;
        }

        public async Task<DueDilClientResponse<SearchCompany>> SearchCompanies(Terms terms)
        {
            var httpClient = CreateHttpClient();

            var response = await httpClient.GetAsync(_searchCompaniesUriBuilder.BuildUri(terms))
                                                .ConfigureAwait(false);

            var dueDilResponse = new DueDilClientResponse<SearchCompany>();

            response.EnsureSuccessStatusCode();

            dueDilResponse.Data = await response.Content.ReadAsAsync<SearchCompany>()
                                                                .ConfigureAwait(false);

            return dueDilResponse;
        }

        public async Task<DueDilClientResponse<Company>> GetCompany(string companyId)
        {
            var httpClient = CreateHttpClient();

            var response = await httpClient.GetAsync(_getCompanyUriBuilder.BuildUri(companyId))
                                                           .ConfigureAwait(false);

            var dueDilResponse = new DueDilClientResponse<Company>();

            response.EnsureSuccessStatusCode();

            dueDilResponse.Data = await response.Content.ReadAsAsync<Company>()
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
