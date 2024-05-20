using System.Security.Cryptography;
using System.Text;
using Isopoh.Cryptography.Argon2;

namespace OES;

/// <summary>
/// Contains the tools for generating salt and hashing passwords with salt.
/// </summary>
public static class PasswordHash
{
    /// <summary>
    /// Generates a salt
    /// </summary>
    /// <returns>Generated salt string.</returns>
    public static string GetSalt()
    {
        var buffer = RandomNumberGenerator.GetBytes(128);
        return Encoding.UTF8.GetString(buffer);
    }

    /// <summary>
    /// Hashes the password with salt using Argon2 algorithm.
    /// </summary>
    /// <param name="password">The password to be hashed.</param>
    /// <param name="salt">The salt to be used.</param>
    /// <returns>The hashed password string.</returns>
    public static string Hash(string password, string salt)
    {
        var argon2Config = new Argon2Config
        {
            Version = Argon2Version.Nineteen,
            Type = Argon2Type.HybridAddressing,
            Password = Encoding.UTF8.GetBytes(password),
            Salt = Encoding.UTF8.GetBytes(salt),
            MemoryCost = 65536,
            TimeCost = 2
        };
        return Argon2.Hash(argon2Config);
    }
}