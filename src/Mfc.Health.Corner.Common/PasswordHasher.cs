namespace Mfc.Health.Corner.Common
{
    public static class PasswordHasher
    {
        public static bool VerifyPassword(string password, string hashPassword)
        {
            var userVerify = BCrypt.Net.BCrypt.Verify(password, hashPassword);

            return userVerify;
        }

        public static string HashPassword(string password)
        {
            var userHashed = BCrypt.Net.BCrypt.HashPassword(password);

            return userHashed;
        }
    }
}
