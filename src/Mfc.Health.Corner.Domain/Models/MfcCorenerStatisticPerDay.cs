using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Domain.Models
{
    public class MfcCorenerStatisticPerDay
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string MfcCornerId { get; set; }
        public int BsmCount { get; set; }
        public int GazCount { get; set; }
        public int PulseCount { get; set; }
        public int BPBIOCount { get; set; }
        public int AnalyzerCount { get; set; }
        public int SpecialistCall { get; set; }
        public int NotFullExamCount { get; set; }
        public int FullExamCount { get; set; }
        public int DoctorsAppointmentCount { get; set; }
        public int SendEmiasCount { get; set; }
        public DateTime Date { get; set; }

    }
}
