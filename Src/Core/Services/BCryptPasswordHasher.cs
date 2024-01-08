
namespace Stll.Core.Services;

public class BCryptPasswordHasher : IPasswordHasher
{
    public string Crypt(string password)
    {
        var salt = BCrypt.Net.BCrypt.GenerateSalt(12);
        return BCrypt.Net.BCrypt.HashPassword(password, salt);
    }

    public bool Verify(string password, string hashed)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashed);
    }
}