using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TodoList
{
    class Security
    {
        //이메일 유효성 검사
        public bool IsValidEmail(string email)
        {
            bool valid = Regex.IsMatch(email, @"[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?");
            return valid;
        }

        //비밀번호 해싱
        public string EncryptSHA256_EUCKR(string phrase)
        {
            int euckrCodepage = 51949;
            Encoding encoder = Encoding.GetEncoding(euckrCodepage);

            SHA256CryptoServiceProvider sha256hasher = new SHA256CryptoServiceProvider();

            byte[] hashedDataBytes = sha256hasher.ComputeHash(encoder.GetBytes(phrase));

            string hashString = string.Empty;

            foreach (byte x in hashedDataBytes)
            {
                hashString += String.Format("{0:x2}", x);
            }

            return Convert.ToBase64String(encoder.GetBytes(hashString));
        }
    }
}
