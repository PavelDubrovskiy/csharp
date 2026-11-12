using System.Collections.Generic;

namespace Mfc.Health.Corner.Persistence.Init
{
    public class UserJson
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<string> RoleNames { get; set; }
    }
}
