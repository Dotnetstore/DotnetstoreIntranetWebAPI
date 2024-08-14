using System.Security.Cryptography;
using System.Text;

namespace Dotnetstore.Intranet.Utility.Services;

public static class HashService
{
    public static string Hash(string rawData)
    {
        var bytes = SHA512.HashData(Encoding.UTF8.GetBytes(rawData));

        var builder = new StringBuilder();
        foreach (var t in bytes)
        {
            builder.Append(t.ToString("x2"));
        }
        return builder.ToString();
    }
}