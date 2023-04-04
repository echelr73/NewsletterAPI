using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using WebAPI.Models;

namespace WebApi.Models
{
    public class ApplicationDbContext
    {
        private readonly IMongoDatabase _database;

        public ApplicationDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoDB"));
            _database = client.GetDatabase("WebApi");
        }

        public IMongoCollection<Newsletter> Newsletters => _database.GetCollection<Newsletter>("NewsletterCollection");
    }
}
