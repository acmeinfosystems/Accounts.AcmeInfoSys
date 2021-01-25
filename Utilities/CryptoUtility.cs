//-----------------------------------------------------------------------
// <copyright file="CryptoUtility.cs" company="Acme Info Systems">
//     Author: Sreejith Gopinathan
//     Copyright (c) Acme Info Systems. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Text;
using System.Security.Cryptography;

namespace Accounts.AcmeInfoSys.Utilities
{
    /// <summary>
    /// A crypto utility class to Encrypt or Decrypt sensitive data.
    /// </summary>
    public class CryptoUtility
    {
        /// <summary>
        /// Encrypts a string.
        /// </summary>
        /// <param name="inputText">Plain text input.</param>
        /// <returns>Encrypted text.</returns>
        public static string Encrypt(string inputText)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(inputText);
            return Convert.ToBase64String(ProtectedData.Protect(bytes, null, DataProtectionScope.CurrentUser));
        }

        /// <summary>
        /// Decrypts an encrypted string.
        /// </summary>
        /// <param name="inputText">Encrypted text input.</param>
        /// <returns>Encrypted plain text.</returns>
        public static string Decrypt(string inputText)
        {
            byte[] bytes = Convert.FromBase64String(inputText);
            return Encoding.Unicode.GetString(ProtectedData.Unprotect(bytes, null, DataProtectionScope.CurrentUser));
        }
    }
}