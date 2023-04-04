using MongoDB.Driver;

namespace WebAPI.Repositories
{
    public class MongoDBRepository
    {
        public MongoClient client;

        public IMongoDatabase db;

        public MongoDBRepository()
        {
            client = new MongoClient("mongodb+srv://echelr73:97XP3wPynoo5vGHh@cluster0.yhl1f2k.mongodb.net/?retryWrites=true&w=majority");

            db = client.GetDatabase("WebApi");

        }

    }
}
