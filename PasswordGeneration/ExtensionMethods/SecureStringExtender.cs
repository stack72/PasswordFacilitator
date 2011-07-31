using System;
using System.Runtime.InteropServices;
using System.Security;

namespace PasswordGeneration.ExtensionMethods
{
    public static class SecureStringExtender
    {
        public static string ConvertToPlainTextString(this SecureString securePassword)
        {
            if (securePassword == null)
                throw new ArgumentNullException("securePassword");

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }

        public static SecureString Scramble(this SecureString securePassword)
        {
            SecureString retSS = securePassword;
            Random random = RandomSeedGenerator.GetRandom();
            int moves = random.Next(securePassword.Length, securePassword.Length * 2);
            for (int i = 0; i < moves; i++)
            {
                int origIndex = random.Next(securePassword.Length);
                int newIndex = random.Next(securePassword.Length);
                char c = retSS.GetAt(origIndex);
                retSS.InsertAt(newIndex, c);
            }
            return retSS;
        }

        public static Char GetAt(this SecureString securePassword, int index)
        {
            if (securePassword.Length < index)
                throw new ArgumentException("The index parameter must not be greater than the string's length.");
            if (index < 0)
                throw new ArgumentException("The index must be 0 or greater.");
            return securePassword.ConvertToPlainTextString().Substring(index, 1).ToCharArray()[0];
        }
    }
}