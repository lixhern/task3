using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    internal class HmacKey
    {
        private byte[] key;
        public byte[] KeyByte { get { return this.key; } }
        public string Key {  get { return BitConverter.ToString(this.key).Replace("-", ""); } }

        public HmacKey()
        {
            this.key = new byte[32];
        }

        public void CreateKey()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(this.key);
            }
        }
    }
}
