using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampusArena
{
        public class MD5_Sifreleme
        {
            public static string MD5_Olustur(string giris)
            {
                using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
                {
                    byte[] girisByte = System.Text.Encoding.ASCII.GetBytes(giris);
                    byte[] karmaByte = md5.ComputeHash(girisByte);
                    return Convert.ToHexString(karmaByte); 
                }
            }
        }
}
