using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
