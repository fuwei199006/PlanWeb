using System;
using System.Text;

namespace Core.Encrypt
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
        public static string Md5(string s)
        {
            var md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            var result = BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(s.Trim())));
            return result;
        }


    
    }
}
