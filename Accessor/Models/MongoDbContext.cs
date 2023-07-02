using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Accessor.Models
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("MongoDBSettings:ConnectionString").Value;
            var databaseName = configuration.GetSection("MongoDBSettings:DatabaseName").Value;

            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<Contact> PhoneBook =>
            _database.GetCollection<Contact>("PhoneBook");
        public IMongoCollection<ContactDTO> PhoneBookPost =>
    _database.GetCollection<ContactDTO>("PhoneBook");
    }
}

