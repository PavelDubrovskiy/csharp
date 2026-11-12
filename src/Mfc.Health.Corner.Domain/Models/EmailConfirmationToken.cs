using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mfc.Health.Corner.Domain.Models
{
    public class EmailConfirmationToken
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }
        [BsonRepresentation(BsonType.String)]
        public Guid Token { get; set; }
    }
}
