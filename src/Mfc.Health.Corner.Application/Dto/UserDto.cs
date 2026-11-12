using System;
using System.Collections.Generic;

namespace Mfc.Health.Corner.Application.Dto
{
    public class UserDto
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public List<RoleDto> Roles { get; set; }
        public bool Blocked { get; set; }
        public DateTime CreatedAt { get; set; }
        public UserManagementDto UserManagement { get; set; }
        public HeadOfMfcDto HeadOfMfc { get; set; }
        public HeadOfDivisionDto HeadOfDivision { get; set; }

        public DistrictDto District { get; set; }
        public MfcCornerDto MfcCorner { get; set; }
    }
}
