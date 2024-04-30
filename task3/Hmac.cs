using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    internal class Hmac
    {
        private byte[] hash;

        public string Hash
        {
            get { return BitConverter.ToString(this.hash).Replace("-", ""); }
        }

        public void CreateHmac(byte[] key, string pcMove)
        {
            using (var hmac = new HMACSHA256(key)) 
            {
                this.hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(pcMove));
            }
        }   
    }
}
