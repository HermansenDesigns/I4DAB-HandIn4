using System;
using I4DABH4.Models;
using Microsoft.Azure.Documents.Client;

namespace I4DABH4.Data.Traderinfo
{
    public class GridRepo:GenericDocumentRepo<GridInfo>
    {
        public GridRepo(DocumentClient client, Uri collectionUri) : base(client, collectionUri)
        {

        }
    }
}