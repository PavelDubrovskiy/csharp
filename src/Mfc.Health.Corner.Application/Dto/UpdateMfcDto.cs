using System;

namespace Mfc.Health.Corner.Application.Dto
{
    public class UpdateMfcDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string TelegtamChatId { get; set; }
        public string DistrictId { get; set; }
        public string Address { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Group { get; set; }

        public string Ip { get; set; }
        public string Port { get; set; }
    }
}
