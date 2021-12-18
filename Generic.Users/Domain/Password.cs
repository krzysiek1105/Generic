using Generic.Shared.Domain;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace Generic.Users.Domain;

public class Password : ValueObject
{
    public string Hash { get; }
    public string Salt { get; }

    public Password(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(128);

        Salt = Convert.ToBase64String(salt);
        Hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA512, 100000, 32));
    }
}