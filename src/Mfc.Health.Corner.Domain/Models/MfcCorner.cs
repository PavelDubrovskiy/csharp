using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mfc.Health.Corner.Domain.Models
{
    public class MfcCorner
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public EquipmentCondition EquipmentCondition { get; set; }
        public string TelegtamChatId { get; set; }
        public string Address { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }
        public string DistrictId { get; set; }
        public string Group { get; set; }

        public string Ip { get; set; }
        public string Port { get; set; }
    }
}

