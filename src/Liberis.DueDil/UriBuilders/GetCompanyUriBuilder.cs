using System;
using Newtonsoft.Json;

namespace LiberisLabs.DueDil.UriBuilders
{
    public class GetCompanyUriBuilder : IGetCompanyUriBuilder
    {
        private readonly string _apiKey;

        public GetCompanyUriBuilder(string apiKey)
        {
            _apiKey = apiKey;
        }

        public Uri BuildUri(string companyId)
        {
            var path = $"companies/{companyId}";
            
            var query = $"?api_key={Uri.EscapeDataString(_apiKey)}";

            var pathAndQuery = path + query;

            return new Uri(pathAndQuery, UriKind.Relative);
        }
    }
}
