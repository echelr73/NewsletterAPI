using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebAPI.Models
{
    public class Newsletter
    {
        [BsonId]
        public ObjectId _id { get; set; }

        [BsonElement("NewsId")]
        public string NewsId
        {
            get => _id.ToString();
            set => _id = ObjectId.Parse(value);
        }

        [BsonElement("Title")]
        public string Title { get; set; }

        [BsonElement("HtmlBody")]
        public string HtmlBody { get; set; }
    }


}
