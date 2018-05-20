using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace I4DABH4.Models
{
    public class ProsumerTradeStats
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public List<ProsumerTradeStat> TradeStats { get; set; }
        public ProsumerTradeStats()
        {

        }

        public ProsumerTradeStats(ProsumerTradeStat tradestat)
        {
            Id = tradestat.Timestamp.ToString("yyMMddHHmm");
            TradeStats = new List<ProsumerTradeStat>()
            {
                tradestat
            };
        }
    }
    public class ProsumerTradeStat
    {
        public long ProsumerId { get; set; }
        public int Producing { get; set; }
        public int Consuming { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
