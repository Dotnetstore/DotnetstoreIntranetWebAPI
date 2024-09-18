using System.Security.Cryptography;

namespace Dotnetstore.Intranet.Utility.Extensions;

public static class HashExtensions
{
    private const int SaltSize = 32;
    private const int HashSize = 64;
    private const int Iterations = 600_000;
    
    private static readonly HashAlgorithmName HashAlgorithmName = HashAlgorithmName.SHA512;
    
    public static string Hash(
        this string password,
        string salt1,
        string salt2,
        string salt3,
        string salt4)
    {
        var value = GetPasswordStringToHash(password, salt1, salt2, salt3, salt4);
        var salt = RandomNumberGenerator.GetBytes(SaltSize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(value, salt, Iterations, HashAlgorithmName, HashSize);
        
        return $"{Convert.ToHexString(hash)}-{Convert.ToHexString(salt)}";
    }
    
    public static bool Verify(
        this string password,
        string salt1,
        string salt2,
        string salt3,
        string salt4, 
        string hashedValue)
    {
        var value = GetPasswordStringToHash(password, salt1, salt2, salt3, salt4);
        var parts = hashedValue.Split('-');
        var salt = Convert.FromHexString(parts[1]);
        var hash = Convert.FromHexString(parts[0]);
        var hashToVerify = Rfc2898DeriveBytes.Pbkdf2(value, salt, Iterations, HashAlgorithmName, HashSize);
        
        return hash.SequenceEqual(hashToVerify);
    }
    
    private static string GetPasswordStringToHash(
        string password, 
        string salt1,
        string salt2,
        string salt3,
        string salt4)
    {
        return $"{salt3}{password}{salt2}{salt4}{salt1}";
    }
}