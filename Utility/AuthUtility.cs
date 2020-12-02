namespace RolePlayGame.Utility
{
    public static class AuthUtility
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var crypto = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = crypto.Key;
                passwordHash = crypto.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}