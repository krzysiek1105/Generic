using System.Security.Cryptography;
using Generic.Shared.Domain;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Generic.Users.Domain;

public class Password : ValueObject
{
    public string Hash { get; }
    public string Salt { get; }

    internal Password(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(128);

        Salt = Convert.ToBase64String(salt);
        Hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA512, 100000, 32));
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Hash;
        yield return Salt;
    }
}