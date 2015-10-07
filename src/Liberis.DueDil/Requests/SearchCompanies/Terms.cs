using Newtonsoft.Json;

namespace LiberisLabs.DueDil.Requests.SearchCompanies
{
    public class Terms
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /*
        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }

        [JsonProperty(PropertyName = "postcode")]
        public string Postcode { get; set; }

        [JsonProperty(PropertyName = "domain")]
        public string Domain { get; set; }
 */
    }
}
