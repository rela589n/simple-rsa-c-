using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace RSA
{
    class RSADecryptor
    {
        PrivateKey privateKey;
        RSAHelper converter;
        public RSADecryptor(PrivateKey privateKey, RSAHelper converter)
        {
            this.privateKey = privateKey;
            this.converter = converter;
        }

        public String decrypt(BigInteger encrypted)
        {
            BigInteger res = BigInteger.ModPow(encrypted, this.privateKey.D, this.privateKey.N);
            return converter.BigIntToText(res);
        }
    }
}