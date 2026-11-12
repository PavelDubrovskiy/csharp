using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mfc.Health.Corner.Domain.Models
{
    public class BaseUserRoleInfo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string UserRoleId { get; set; }
    }
}
