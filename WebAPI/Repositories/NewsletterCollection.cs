using MongoDB.Bson;
using MongoDB.Driver;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class NewsletterCollection : INewsletterCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Newsletter> _newsletterCollection;

        public NewsletterCollection()
        {
            _newsletterCollection = _repository.db.GetCollection<Newsletter>("NewsletterCollection");
        }
        public async Task Delete(string id)
        {
            var filter = Builders<Newsletter>.Filter.Eq(n => n._id, new ObjectId(id));
            await _newsletterCollection.DeleteOneAsync(filter);
        }

        public async Task<Newsletter> Get(string id)
        {
            return await _newsletterCollection.FindAsync(
                new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }

        public async Task<List<Newsletter>> GetAll()
        {
            return await _newsletterCollection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task Insert(Newsletter newsletter)
        {
            await _newsletterCollection.InsertOneAsync(newsletter);
        }

        public async Task Update(Newsletter newsletter)
        {
            var filter = Builders<Newsletter>.Filter.Eq(n => n._id, new ObjectId(newsletter.NewsId));

            await _newsletterCollection.ReplaceOneAsync(filter, newsletter);
        }
    }
}
