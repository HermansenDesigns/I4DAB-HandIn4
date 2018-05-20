using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace I4DABH4.Data.Traderinfo
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly DocumentClient _client;
        readonly string _host = "https://localhost:8081";
        readonly string _key = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        readonly string _dbname = "TraderInfo";
        readonly string _collection = "TestCollection";
        private readonly Uri _collectionUri;
        private TradesRepo _tradesRepo;


        public TradesRepo TradesRepo => this._tradesRepo ?? new TradesRepo(_client, _collectionUri);


        private bool disposed = false;

        public UnitOfWork()
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
                Console.WriteLine("No cosmosDB emulator found at " + _host);

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
