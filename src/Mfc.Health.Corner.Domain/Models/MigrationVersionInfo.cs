using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mfc.Health.Corner.Domain.Models
{
    public class MigrationVersionInfo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Version { get; set; }
        public DateTime AppliedOn { get; set; }
        public string Name { get; set; }
    }
}
