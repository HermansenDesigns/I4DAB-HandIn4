using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace I4DABH4.Models
{
    public class BuyTradeStat
    {
        public long ProsumerId;
        public long BuyFrom;
        public int Amount;
        [JsonProperty(PropertyName = "id")]
        public DateTime Timestamp;
    }
}
