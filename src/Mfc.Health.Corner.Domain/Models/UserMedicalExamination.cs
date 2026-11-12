using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;

namespace Mfc.Health.Corner.Domain.Models
{
    public class UserMedicalExamination
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string MfcCornerId { get; set; }
        public string PhoneNumber { get; set; }
        public string Age { get; set; }
        public bool Male { get; set; }
        public List<string> TestNames { get; set; }
        public List<string> ComplitedTestIds { get; set; }
        public Examination Examination { get; set; }

        [BsonRepresentation(BsonType.String)]
        public DateTimeOffset CreateDate { get; set; }
        [BsonRepresentation(BsonType.String)]
        public DateTimeOffset CompleteDate { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsExaminationResultShowed { get; set; }
        public List<FailedAttemptsCount> FailedAttempts { get; set; }
    }

    public class FailedAttemptsCount
    {
        public string DeviceName { get; set; }
        public int Count { get; set; }
    }
}
