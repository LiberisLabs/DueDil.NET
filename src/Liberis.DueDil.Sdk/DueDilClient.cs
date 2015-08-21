using System;
using System.CodeDom;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Liberis.DueDil.Sdk.Requests.SearchCompanies;
using Liberis.DueDil.Sdk.Responses;
using Liberis.DueDil.Sdk.Responses.Companies;
using Liberis.DueDil.Sdk.UriBuilders;

namespace Liberis.DueDil.Sdk
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

        public async Task<DueDilClientResponse<DueDilResponse<CompanyResult>>> GetCompany(string companyId)
        {
            var httpClient = CreateHttpClient();

            var response = await httpClient.GetAsync(_getCompanyUriBuilder.BuildUri(companyId))
                                                           .ConfigureAwait(false);

            var dueDilResponse = new DueDilClientResponse<DueDilResponse<CompanyResult>>();

            response.EnsureSuccessStatusCode();

            dueDilResponse.Data = await response.Content.ReadAsAsync<DueDilResponse<CompanyResult>>()
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
