using System;
using Liberis.DueDil.Sdk.Requests.SearchCompanies;
using Newtonsoft.Json;

namespace Liberis.DueDil.Sdk.UriBuilders
{
    public class SearchCompaniesUriBuilder : ISearchCompaniesUriBuilder
    {
        private readonly Uri _baseUri;
        private readonly string _apiKey;

        public SearchCompaniesUriBuilder(Uri baseUri, string apiKey)
        {
            _baseUri = baseUri;
            _apiKey = apiKey;
        }

        public Uri BuildUri(Terms terms)
        {
            var uriBuilder = new UriBuilder(_baseUri);

            uriBuilder.Path = string.Format("{0}/companies", Version.V3);

            var filters = JsonConvert.SerializeObject(terms);
            uriBuilder.Query = string.Format("api_key={0}&filters={1}", _apiKey, filters);

            return uriBuilder.Uri;
        }
    }
}
