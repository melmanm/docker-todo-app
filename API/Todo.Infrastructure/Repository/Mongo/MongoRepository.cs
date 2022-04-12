using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain;

namespace Todo.Infrastructure.Repository.Mongo
{
    public class MongoRepository<T> : IRepository<T> where T : BaseEntity
    {

        private IMongoCollection<T> _items;

        public MongoRepository(IOptions<MongoConfiguration> mongoConfiguration)
        {
            var config = mongoConfiguration.Value;
            MongoClient client = new MongoClient($"mongodb://{config.MONGO_LOGIN}:{config.MONGO_PASSWORD}@{config.MONGO_URL}");
            var database = client.GetDatabase(config.DATABSE_NAME);
            _items = database.GetCollection<T>(typeof(T).FullName);
        }

        public void Add(T item)
        {
            _items.InsertOne(item);
        }

        public T Get(Guid id)
        {
            return _items.Find(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return _items.Find(_ => true).ToList();
        }

        public void Remove(Guid id)
        {
            _items.DeleteOne(x => x.Id == id);
        }

        public void SaveChanges(T item)
        {
            _items.ReplaceOne(x=>x.Id == item.Id, item);
        }
    }
}
