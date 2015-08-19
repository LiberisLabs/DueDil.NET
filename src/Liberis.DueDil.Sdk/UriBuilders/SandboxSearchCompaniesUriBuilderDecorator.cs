using System;
using Liberis.DueDil.Sdk.Requests.SearchCompanies;

namespace Liberis.DueDil.Sdk.UriBuilders
{
    public class SandboxSearchCompaniesUriBuilderDecorator : ISearchCompaniesUriBuilder
    {
        private readonly ISearchCompaniesUriBuilder _searchCompaniesUriBuilder;

        public SandboxSearchCompaniesUriBuilderDecorator(ISearchCompaniesUriBuilder searchCompaniesUriBuilder)
        {
            _searchCompaniesUriBuilder = searchCompaniesUriBuilder;
        }

        public Uri BuildUri(Terms terms)
        {
            var uri = _searchCompaniesUriBuilder.BuildUri(terms);

            var uriBuilder = new UriBuilder(uri);

            uriBuilder.Path = "sandbox" + uriBuilder.Path;

            return uriBuilder.Uri;
        }
    }
}