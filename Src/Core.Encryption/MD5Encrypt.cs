using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Core.Encryption
{
    /// <summary>
    /// 加密字符串辅助类
    /// </summary>
    public class MD5Encrypt
    {
        /// <summary>
        /// MD5 hash加密
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string MD5(string s)
        {
            var md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            var result = BitConverter.ToString(md5.ComputeHash(UnicodeEncoding.UTF8.GetBytes(s.Trim())));
            return result;
        }


    
    }
}
