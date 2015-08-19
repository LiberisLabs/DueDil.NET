using System;
using Liberis.DueDil.Sdk.Requests.SearchCompanies;

namespace Liberis.DueDil.Sdk.UriBuilders
{
    public interface ISearchCompaniesUriBuilder
    {
        Uri BuildUri(Terms terms);
    }
}