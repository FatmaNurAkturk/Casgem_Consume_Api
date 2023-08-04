using EntityLayer.Concrete;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context
    {
        private readonly IMongoDatabase _mongoDatabase;

        public Context(IConfiguration configuration)
        {
            var connectionString = "mongodb://localhost:27017";

            var mongoClient = new MongoClient(connectionString);

            _mongoDatabase = mongoClient.GetDatabase("CasgemEmlakApi");
        }

        public IMongoCollection<Category> Categories => _mongoDatabase.GetCollection<Category>("Categories");
        public IMongoCollection<Comment> Comments => _mongoDatabase.GetCollection<Comment>("Comments");
        public IMongoCollection<Duyuru> Duyurus => _mongoDatabase.GetCollection<Duyuru>("Duyurus");
        public IMongoCollection<Employee> Employees => _mongoDatabase.GetCollection<Employee>("Employees");
        public IMongoCollection<Message> Messages => _mongoDatabase.GetCollection<Message>("Messages");
        public IMongoCollection<User> Users => _mongoDatabase.GetCollection<User>("Users");

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _mongoDatabase.GetCollection<T>(collectionName);
        }

    }
}
