using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.Classes
{
    static class PasswordUtils
    {
        public static string ComputePassword(SecureString password, String salt)
        {
            var saltedPassword = password.Copy();
            foreach (var saltChar in salt)
            {
                saltedPassword.AppendChar(saltChar);
            }

            saltedPassword.MakeReadOnly();

            var passwordBytes = new byte[saltedPassword.Length * 2];
            var sha = new SHA512Managed();
            var nativeString = IntPtr.Zero;

            try
            {
                nativeString = Marshal.SecureStringToBSTR(saltedPassword);
                Marshal.Copy(nativeString, passwordBytes, 0, passwordBytes.Length);
            }
            finally
            {
                Marshal.ZeroFreeBSTR(nativeString);
            }

            byte[] hashedPassword = sha.ComputeHash(passwordBytes);
            sha.Clear();
            return Convert.ToBase64String(hashedPassword);
        }

        private const int SaltLength = 16;

        public static string CreateSalt()
        {
            var random = new RNGCryptoServiceProvider();
            var salt = new byte[SaltLength];

            random.GetBytes(salt);
            return Convert.ToBase64String(salt);
        }
    }
}
