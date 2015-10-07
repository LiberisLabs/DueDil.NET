using Newtonsoft.Json;

namespace LiberisLabs.DueDil.Responses.SearchCompanies
{
    public class SearchCompanyResult
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "locale")]
        public string Locale { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        
        [JsonProperty(PropertyName = "company_url")]
        public string CompanyUrl { get; set; }
    }
}
