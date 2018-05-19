using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace I4DABH4.Models
{
    public class ProsumerTradeStat
    {
        public long ProsumerId;
        public int Producing;
        public int Consuming;
        [JsonProperty(PropertyName = "id")]
        public DateTime Timestamp;
        
    }
}
