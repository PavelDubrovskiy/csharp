using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Mfc.Health.Corner.Domain.Models
{
    public class MfcSrpecialistCall
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string MfcCornerId { get; set; }
        public int Count { get; set; }
    }
}
