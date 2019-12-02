using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace RSA
{
    class RSAEncryptor
    {
        PublicKey key;
        RSAHelper converter;
        public RSAEncryptor(PublicKey key, RSAHelper converter)
        {
            this.key = key;
            this.converter = converter;
        }

        public BigInteger encrypt(String message)
        {
            BigInteger msg = converter.TextToBigInt(message);
            return BigInteger.ModPow(msg, this.key.E, this.key.N);
        }
    }
}
