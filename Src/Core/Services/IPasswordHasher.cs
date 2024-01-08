namespace Stll.Core.Services;

public interface IPasswordHasher
{
    string Crypt(string password);
    bool Verify(string password, string hashed);
}