using System;
using System.Collections.Generic;

namespace Mfc.Health.Corner.Application.Dto
{
    public class UpdateUserDto
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public bool Blocked { get; set; }
        public List<string> RoleNames { get; set; }
        public string DistrictId { get; set; }
        public string MfcCornerId { get; set; }
    }
}
