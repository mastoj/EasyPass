using System;
using System.Security.Cryptography;
using System.Text;

namespace EasyPass.Encryption
{
    public class DPAPIEncryptor : IEncryptor
    {
        public string Encrypt(string textToEnrypt)
        {
            var encryptedData = ProtectedData.Protect(Encoding.UTF8.GetBytes(textToEnrypt), null,
                                                      DataProtectionScope.CurrentUser);
            var encryptedString = Convert.ToBase64String(encryptedData);
            return encryptedString;
        }

        public string Decrypt(string textToDecrypt)
        {
            var encryptedData = Convert.FromBase64String(textToDecrypt);
            var decryptedData = ProtectedData.Unprotect(encryptedData, null,
                                                        DataProtectionScope.CurrentUser);
            return Encoding.UTF8.GetString(decryptedData);
        }
    }
}