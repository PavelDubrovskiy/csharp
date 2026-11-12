using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mfc.Health.Corner.Domain.Models
{
    public class UserRole
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string UserId { get; set; }
        public string RoleId { get; set; }
    }
}
