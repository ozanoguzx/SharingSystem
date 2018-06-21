using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Security.Cryptography;

namespace BLL
{
    public class Tools
    {
        public static string Sifrele(string unhashedValue)
        {
            SHA512 shaM = new SHA512Managed();
            byte[] hash =
             shaM.ComputeHash(Encoding.ASCII.GetBytes(unhashedValue));

            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in hash)
            {
                stringBuilder.AppendFormat("{0:x2}", b);
            }
            return stringBuilder.ToString();
        }

        public static bool LoginKullanici(string email, string password, bool userNameMi, out int userID)
        {
            BasEntities db = new BasEntities();
          

            bool sonuc = false;
            int id = 0;

          

            if (id > 0)
            {
                sonuc = true;
            }
            else
            {
                sonuc = false;
            }

            userID = id;
            return sonuc;
        }
    }
}
