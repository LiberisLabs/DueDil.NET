using Newtonsoft.Json;

namespace Liberis.DueDil.Sdk.Responses
{
    public class DueDilResponse<T>
    {
        [JsonProperty(PropertyName = "request_id")]
        public string RequestId { get; set; }

        [JsonProperty(PropertyName = "response")]
        public T Response { get; set; }
    }
}
