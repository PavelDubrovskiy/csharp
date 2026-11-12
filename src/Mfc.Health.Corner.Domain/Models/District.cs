using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mfc.Health.Corner.Domain.Models
{
    public class District
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
