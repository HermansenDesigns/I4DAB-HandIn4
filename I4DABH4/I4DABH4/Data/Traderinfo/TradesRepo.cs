using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using I4DABH4.Models;
using Microsoft.Azure.Documents.Client;

namespace I4DABH4.Data.Traderinfo
{
    public class TradesRepo : GenericDocumentRepo<ProsumerTradeStats>, ITradesRepo
    {
        public TradesRepo(DocumentClient client, Uri collectionUri) : base(client, collectionUri)
        {
        }

        public IEnumerable<ProsumerTradeStat> GetAllById(long prosumerId)
        {
            var relevantDocs = base.Find(stat => stat.TradeStats.Exists(item => item.ProsumerId == prosumerId));
            var listofstats = new List<ProsumerTradeStat>();
            foreach (var doc in relevantDocs)
            {
                listofstats.AddRange(doc.TradeStats.Where(item => item.ProsumerId == prosumerId));
            }

            return listofstats;
        }
        public ProsumerTradeStat GetLatestById(long prosumerId)
        {
            var relevantDoc = base.FindLatestOrDefault(stat => stat.TradeStats.Exists(item => item.ProsumerId == prosumerId));

            return relevantDoc.TradeStats.FindLast(item => item.ProsumerId == prosumerId);
        }


        public void Add(ProsumerTradeStat prosumerInfo)
        {
            var proinfos = new ProsumerTradeStats(prosumerInfo);
            var last = GetLatestById(prosumerInfo.ProsumerId);
            int netImpact;
            if (last == null)
                netImpact = (prosumerInfo.Producing - prosumerInfo.Consuming);
            else
                netImpact = (last.Producing - prosumerInfo.Producing) - (last.Consuming - prosumerInfo.Consuming);

            var doc = base.Get(proinfos.Id);
            if (doc == null)
            {
                var recentdoc = base.GetAll().LastOrDefault();
                proinfos.NetBalance = recentdoc?.NetBalance ?? 0;
                base.Add(proinfos);
            }
            else
            {
                doc.TradeStats.Add(prosumerInfo);
                doc.NetBalance += netImpact;
                base.Update(doc);
            }
        }

        public IEnumerable<ProsumerTradeStat> GetByDate(string datetime)
        {
            var tradeAggregate = new List<ProsumerTradeStat>();
            foreach (var item in base.StartsWith(datetime))
            {
                tradeAggregate.AddRange(item.TradeStats);
            }
            return tradeAggregate;
        }


    }
}
