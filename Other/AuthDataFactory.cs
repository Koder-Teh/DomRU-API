using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace DomruAPI.Other
{
    internal class AuthDataFactory
    {
        /// <summary>
        /// Стандартный перевод из строки в строку, которая SHA-1
        /// </summary>
        /// <param name="password">Пароль от Аккаунта</param>
        /// <returns></returns>
        public static string hash1(string password)
        {
            byte[] g = Encoding.Latin1.GetBytes(password);
            SHA1 sha1 = SHA1.Create();
            byte[] p = sha1.ComputeHash(g);
            return Convert.ToBase64String(p);
        }

        /// <summary>
        /// Из строкбилдера мы загружаем строки в последовательности, потом переводим и получаем строку в MD5
        /// </summary>
        /// <param name="login">Номер Договора</param>
        /// <param name="password">Пароль от Аккаунта</param>
        /// <param name="time">Мировое время (формат: "yyyyMMddHHmmss")</param>
        /// <returns></returns>
        public static string hash2(string login, string password, string time)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("DigitalHomeNTK");
            builder.Append("password");
            builder.Append(login);
            builder.Append(password);
            builder.Append(time);
            builder.Append("789sdgHJs678wertv34712376");
            MD5 md5 = MD5.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(builder.ToString());
            byte[] changebytes = md5.ComputeHash(bytes);
            return Convert.ToHexString(changebytes);
        }
    }
}
