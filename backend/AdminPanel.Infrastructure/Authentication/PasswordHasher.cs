using AdminPanel.Application.Abstractions.Authentication;

namespace AdminPanel.Infrastructure.Authentication;

public class PasswordHasher : IPasswordHasher
{
    public string Generate(string password)
    {
        return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
    }
    
    public bool Verify(string password, string hash)
    {
        return BCrypt.Net.BCrypt.EnhancedVerify(password, hash);
    }
}