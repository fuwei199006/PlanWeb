using System;
using System.Text;

namespace Core.Encrypt
{
    public class Base64Encrypt
    {
        /// <summary>
        /// 将普通文本转换成Base64编码的文本
        /// </summary>
        /// <param name="value">普通文本</param>
        /// <returns></returns>
        public string StringToBase64String(string value)
        {
            byte[] binBuffer = (new UnicodeEncoding()).GetBytes(value);
            int base64ArraySize = (int)Math.Ceiling(binBuffer.Length / 3d) * 4;
            char[] charBuffer = new char[base64ArraySize];
            Convert.ToBase64CharArray(binBuffer, 0, binBuffer.Length, charBuffer, 0);
            string s = new string(charBuffer);
            return s;
        }

        /// <summary>
        /// 将Base64编码的文本转换成普通文本
        /// </summary>
        /// <param name="base64">Base64编码的文本</param>
        /// <returns></returns>
        public string Base64StringToString(string base64)
        {
            char[] charBuffer = base64.ToCharArray();
            byte[] bytes = Convert.FromBase64CharArray(charBuffer, 0, charBuffer.Length);
            return (new UnicodeEncoding()).GetString(bytes);
        }

        /// <summary>
        /// 将Byte[]转换成Base64编码文本
        /// </summary>
        /// <param name="binBuffer">Byte[]</param>
        /// <returns></returns>
        public string ToBase64(byte[] binBuffer)
        {
            int base64ArraySize = (int)Math.Ceiling(binBuffer.Length / 3d) * 4;
            char[] charBuffer = new char[base64ArraySize];
            Convert.ToBase64CharArray(binBuffer, 0, binBuffer.Length, charBuffer, 0);
            string s = new string(charBuffer);
            return s;
        }

        /// <summary>
        /// 将Base64编码文本转换成Byte[]
        /// </summary>
        /// <param name="base64">Base64编码文本</param>
        /// <returns></returns>
        public byte[] Base64ToBytes(string base64)
        {
            char[] charBuffer = base64.ToCharArray();
            byte[] bytes = Convert.FromBase64CharArray(charBuffer, 0, charBuffer.Length);
            return bytes;
        }
    }
}