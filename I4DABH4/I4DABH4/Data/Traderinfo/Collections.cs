using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using I4DABH4.Data.Prosumerinfo;
using I4DABH4.Models;
using I4DABH4.Repos;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace I4DABH4.Data.Traderinfo
{
    public class Collections : IDisposable, ICollections
    {
        private readonly DocumentClient _client;
        readonly string _host = "https://f18i4dab.documents.azure.com:443/";
        readonly string _key = "vmbfFVnIqKYcdYCVRqHXDpkqh471dqeELczO4rbVKoYpI5NUJ4D34DegxTFTS4FhNiCw6B477WVqhjqNABSdow==";
        readonly string _dbname = "F18I4DABH4Gr8";        
        readonly string _collection = "ProsumerCollection";
        private readonly Uri _collectionUri;
        private TradesCollectionRepo _tradesRepo;


        public TradesCollectionRepo TradesRepo
        {
            get
            {
                if(this._tradesRepo== null)
                    _tradesRepo = new TradesCollectionRepo(_client, _collectionUri);
                return _tradesRepo;
            }
        }


        private bool disposed = false;

        public Collections()
        {
            try
            {
                _client = new DocumentClient(new Uri(_host), _key);

                _client.CreateDatabaseIfNotExistsAsync(new Database() { Id = _dbname }).Wait();

                _client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(_dbname),
                    new DocumentCollection { Id = _collection }).Wait();
                
                _collectionUri = UriFactory.CreateDocumentCollectionUri(_dbname, _collection);

            }
            catch (Exception e)
            {
                Console.WriteLine("No cosmosDB found at " + _host);

                Console.WriteLine(e);
                throw;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _client.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
