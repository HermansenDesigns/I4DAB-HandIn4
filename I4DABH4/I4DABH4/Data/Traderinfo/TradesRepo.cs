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

        public void Add(ProsumerTradeStat prosumerInfo)
        {
            var proinfos = new ProsumerTradeStats(prosumerInfo);

            var doc = base.Get(proinfos.Id);
            if (doc == null)
            {
                base.Add(proinfos);
            }
            else
            {
                doc.TradeStats.Add(prosumerInfo);   
                base.Update(doc);
            }
        }

    }
}
