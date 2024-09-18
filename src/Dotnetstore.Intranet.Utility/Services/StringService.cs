using System.Runtime.InteropServices;
using System.Security;

namespace Dotnetstore.Intranet.Utility.Services;

public static class StringService
{
    private static readonly Random Random = new();
    
    public static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZÅÄÖabcdefghijklmnopqrstuvwxyzåäö#!%&?0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[Random.Next(s.Length)]).ToArray());
    }
    
    public static string ToNormalString(this SecureString secureString)
    {
        if (secureString.Length == 0)
            return string.Empty;
        
        var intPtr = IntPtr.Zero;
        
        try
        {
            intPtr = Marshal.SecureStringToGlobalAllocUnicode(secureString);
            return Marshal.PtrToStringUni(intPtr) ?? string.Empty;
        }
        finally
        {
            if (intPtr != IntPtr.Zero)
            {
                Marshal.ZeroFreeGlobalAllocUnicode(intPtr);
            }
        }
    }
    
    public static unsafe SecureString ToSecureString(this string str)
    {
        if (string.IsNullOrEmpty(str))
            return new SecureString();
        
        fixed (char* ptr = str)
        {
            return new SecureString(ptr, str.Length);
        }
    }
}