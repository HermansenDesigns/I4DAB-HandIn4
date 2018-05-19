using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using I4DABH4.Models;
using Microsoft.Azure.Documents.Client;

namespace I4DABH4.Data.Traderinfo
{
    public class TradesRepo : GenericDocumentRepo<ProsumerTradeStat>
    {
        public TradesRepo(DocumentClient client, Uri collectionUri) : base(client, collectionUri)
        {
        }

        public override void Add(ProsumerTradeStat prosumerInfo)
        {
            var doc = base.Get(prosumerInfo);
            if (doc == null)
            {
                base.Add(prosumerInfo);
            }
            else
            {
                doc.Add(prosumerInfo);
                base.Update(doc);
            }
        }

    }
}
