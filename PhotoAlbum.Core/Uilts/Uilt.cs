using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PhotoAlbum.Core.Uilts
{
    public static class Uilt
    {
        /// <summary>
        /// 获得md5
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static string GetMd5(byte[] buffer)
        {
            using (MD5 mi = MD5.Create())
            {
                //开始加密
                byte[] newBuffer = mi.ComputeHash(buffer);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < newBuffer.Length; i++)
                {
                    sb.Append(newBuffer[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
        /// <summary>
        /// 获取字节
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static byte[]  GetBytes(Stream stream)
        {
            MemoryStream ms = new MemoryStream();
            int n = 0;
            byte[] buffer = new byte[102400];
            while ((n = stream.Read(buffer, 0, buffer.Length)) > 0)
                ms.Write(buffer, 0, n);
            return ms.ToArray();
        }
        public static void Zip()
        {
            
            
        }
    }
}
