using System;
using System.Collections.Generic;
using LiberisLabs.DueDil.Requests.Companies;
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

        public Uri BuildUri(Locale locale, string companyId)
        {
            var path = $"{_localeMap[locale]}/companies/{companyId}";
            
            var query = $"?api_key={Uri.EscapeDataString(_apiKey)}";

            var pathAndQuery = path + query;

            return new Uri(pathAndQuery, UriKind.Relative);
        }

        private readonly IReadOnlyDictionary<Locale, string> _localeMap = new Dictionary<Locale, string>
        {
            {Locale.Uk, "uk"},
            {Locale.Roi, "roi"}
        };
    }
}
