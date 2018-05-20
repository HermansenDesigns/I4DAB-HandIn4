using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace I4DABH4.Models
{
    public class ProsumerTradeStats
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public int NetBalance { get; set; }
        public List<ProsumerTradeStat> TradeStats { get; set; }
        public ProsumerTradeStats()
        {

        }

        public ProsumerTradeStats(ProsumerTradeStat tradestat)
        {
            Id = DateToId(tradestat.Timestamp);
            TradeStats = new List<ProsumerTradeStat>()
            {
                tradestat
            };
        }

        public static string DateToId(DateTime time)
        {
            return time.ToString("yyMMddHH");
        }

        public static DateTime IdToDate(string time)
        {
            var result = new DateTime();
            DateTime.TryParseExact(time, "yyMMddHH", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out result);
            return result;
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
