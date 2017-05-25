using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
namespace StringHandling
{
    /// <summary>
    /// ����/�����ַ���
    /// </summary>
    public class Security
    {
        /// <summary>
        /// MD5 ����
        /// </summary>
        /// <param name="passWord">��Ҫ���ܵ��ַ���</param>
        /// <returns>���ܺ���ַ���</returns>
        public static string Md5(string passWord)
        {
            Byte[] clearBytes = new UnicodeEncoding().GetBytes(passWord);
            Byte[] hashedBytes = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(clearBytes);
            return BitConverter.ToString(hashedBytes);
        }

        /// <summary>
        /// SHA1 ����
        /// </summary>
        /// <param name="passWord">��Ҫ���ܵ��ַ���</param>
        /// <returns>���ܺ���ַ���</returns>
        public static string Sha1(string passWord)
        {
            Byte[] clearBytes = new UnicodeEncoding().GetBytes(passWord);
            Byte[] hashedBytes = ((HashAlgorithm)CryptoConfig.CreateFromName("SHA1")).ComputeHash(clearBytes);
            return BitConverter.ToString(hashedBytes);
        }
    }
}
