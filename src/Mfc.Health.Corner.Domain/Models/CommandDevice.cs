using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Mfc.Health.Corner.Domain.Models
{
    public class CommandDevice
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }
        public string Group { get; set; }
        public string Command { get; set; }
    }
}
