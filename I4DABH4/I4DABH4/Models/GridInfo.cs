using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace I4DABH4.Models
{
    public class GridInfo
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public int NetBalance { get; set; }
        public List<int> ProsumerIds { get; set; }

    }
}
