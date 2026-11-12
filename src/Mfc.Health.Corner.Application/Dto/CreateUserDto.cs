using System.Collections.Generic;

namespace Mfc.Health.Corner.Application.Dto
{
    public class CreateUserDto
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public bool Blocked { get; set; }
        public List<string> RoleNames { get; set; } = new List<string>();
        public string DistrictId { get; set; }
        public string MfcCornerId { get; set; }
    }
}
