using System;

namespace Mfc.Health.Corner.Application.Dto
{
    public class ConfirmEmailDto
    {
        public string Password { get; set; }
        public Guid? Token { get; set; }
    }
}
