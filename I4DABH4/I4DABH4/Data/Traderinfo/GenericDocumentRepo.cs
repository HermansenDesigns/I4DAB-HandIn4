using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;


namespace I4DABH4.Data.Traderinfo
{
    public class GenericDocumentRepo<TEntity> : IGenericDocumentRepo<TEntity> where TEntity : class
    {
        private readonly DocumentClient _client;
        private readonly Uri _collectionUri;
        private readonly PropertyInfo _modelId;
        public GenericDocumentRepo(DocumentClient client, Uri collectionUri)
        {
            try
            {
                _modelId = TryToFindId();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e);
                throw;
            }
            _client = client;
            _collectionUri = collectionUri;

        }
        public virtual TEntity Get(string id)
        {
            return _client.CreateDocumentQuery<TEntity>(
                _collectionUri,
                "Select * from " + typeof(TEntity).Name + " Where " + typeof(TEntity).Name + ".id='" + id + "'").AsEnumerable()?.FirstOrDefault();
        }
        public virtual TEntity Get(TEntity entity)
        {
            return GetDocument(entity) as TEntity;
        }

        private Document GetDocument(TEntity entity)
        {
            return _client.CreateDocumentQuery(_collectionUri).Where(predicate: c => c.Id == _modelId.GetValue(entity).ToString()).AsEnumerable()?.FirstOrDefault();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _client.CreateDocumentQuery<TEntity>(
                _collectionUri,
                "Select * from " + typeof(TEntity).Name);
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _client.CreateDocumentQuery<TEntity>(_collectionUri)
                        .Where(predicate).AsEnumerable();

        }
        public virtual void Add(TEntity entity)
        {
            try
            {
                var item = GetDocument(entity);
                if (item == null)
                    _client.CreateDocumentAsync(_collectionUri, entity).Wait();
                
            }
            catch (DocumentClientException e)
            {
                Console.WriteLine(e);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            _client.CreateDocumentAsync(_collectionUri, entities).Wait();
        }
        public virtual void Remove(TEntity entity)
        {
            try
            {
                var doc = GetDocument(entity);
                var response = _client.DeleteDocumentAsync(doc.SelfLink).Result;

            }
            catch (DocumentClientException e)
            {
                Console.WriteLine(e);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            //  _client.Set<TEntity>().RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            try
            {
                var doc = GetDocument(entity);
                var response = _client.ReplaceDocumentAsync(doc.SelfLink, entity).Result;
            }
            catch (DocumentClientException e)
            {
                Console.WriteLine(e);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private PropertyInfo TryToFindId()
        {
            var type = typeof(TEntity);
            var properties = type.GetProperties();
            var id = properties.SingleOrDefault(key =>
            {
                var jsonId = key.GetCustomAttributes(typeof(JsonPropertyAttribute), true);
                if (jsonId.Length < 1)
                    return false;
                var propname = ((JsonPropertyAttribute)jsonId.FirstOrDefault())?.PropertyName;
                return propname == "id";
            });
            if (id == null)
                throw new ArgumentNullException("id");
            return id;
        }
    }
}
