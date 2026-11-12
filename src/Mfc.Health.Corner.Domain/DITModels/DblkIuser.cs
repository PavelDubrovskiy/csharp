using System;

namespace Mfc.Health.Corner.Domain.DITModels
{
    public partial class DblkIuser
    {
        public uint Id { get; set; }
        public uint Igroup { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Secondname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Pass { get; set; }
        public string Changepasstoken { get; set; }
        public string Token { get; set; }
        public DateTime Expdate { get; set; }
        public string Avatar { get; set; }
        public string Gender { get; set; }
        public string Language { get; set; }
        public string Fb { get; set; }
        public string Vk { get; set; }
        public string Go { get; set; }
        public string Tw { get; set; }
        public string Ya { get; set; }
        public string Li { get; set; }
        public DateTime Ldate { get; set; }
        public string Ip { get; set; }
        public DateTime Edate { get; set; }
        public int Author { get; set; }
        public string Scanner { get; set; }
        public DateTime Cdate { get; set; }
        public bool Visible { get; set; }
        public bool Removed { get; set; }
    }
}
