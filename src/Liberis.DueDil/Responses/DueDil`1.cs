using Newtonsoft.Json;

namespace LiberisLabs.DueDil.Responses
{
    public class DueDil<T>
    {
        [JsonProperty(PropertyName = "request_id")]
        public string RequestId { get; set; }

        [JsonProperty(PropertyName = "response")]
        public T Response { get; set; }
    }
}
