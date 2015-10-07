using System;
using LiberisLabs.DueDil.Requests.SearchCompanies;
using Newtonsoft.Json;

namespace LiberisLabs.DueDil.UriBuilders
{
    public class SearchCompaniesUriBuilder : ISearchCompaniesUriBuilder
    {
        private readonly string _apiKey;

        public SearchCompaniesUriBuilder(string apiKey)
        {
            _apiKey = apiKey;
        }

        public Uri BuildUri(Terms terms)
        {
            var path = "companies";

            var filters = JsonConvert.SerializeObject(terms, new JsonSerializerSettings() {NullValueHandling = NullValueHandling.Ignore});
            var query = $"?api_key={Uri.EscapeDataString(_apiKey)}&filters={Uri.EscapeDataString(filters)}";

            var pathAndQuery = path + query;

            return new Uri(pathAndQuery, UriKind.Relative);
        }
    }
}
