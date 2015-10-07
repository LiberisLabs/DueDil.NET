using System;
using LiberisLabs.DueDil.Requests.SearchCompanies;

namespace LiberisLabs.DueDil.UriBuilders
{
    public interface ISearchCompaniesUriBuilder
    {
        Uri BuildUri(Terms terms);
    }
}