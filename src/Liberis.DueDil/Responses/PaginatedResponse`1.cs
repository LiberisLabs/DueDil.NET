using System.Collections.Generic;
using Newtonsoft.Json;

namespace LiberisLabs.DueDil.Responses
{
    public class PaginatedResponse<T>
    {
        [JsonProperty(PropertyName = "pagination")]
        public Pagination Pagination { get; set; }

        [JsonProperty(PropertyName = "data")]
        public List<T> Data { get; set; }
    }
}
