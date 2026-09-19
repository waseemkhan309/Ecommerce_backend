using BC = BCrypt.Net.BCrypt;

namespace Ecommerce_backend.Services.PasswordHash
{
    public class PasswordHash : IPasswordHash
    {
        public string HashPassword(string password)
        {
            return BC.HashPassword(password, workFactor: 12);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            return BC.Verify(password, hashedPassword);
        }
    }
}
