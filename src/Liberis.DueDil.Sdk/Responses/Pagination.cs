using Newtonsoft.Json;

namespace Liberis.DueDil.Sdk.Responses
{
    public class Pagination
    {
        [JsonProperty(PropertyName = "previous_url")]
        public string PreviousUrl { get; set; }

        [JsonProperty(PropertyName = "next_url")]
        public string NextUrl { get; set; }

        [JsonProperty(PropertyName = "total")]
        public int Total { get; set; }
    }

}
