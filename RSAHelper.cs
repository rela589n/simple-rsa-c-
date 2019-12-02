using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RSA
{
    class RSAHelper
    {
        public BigInteger TextToBigInt(String str)
        {
            return new BigInteger(Encoding.UTF8.GetBytes(str));
        }

        public String BigIntToText(BigInteger integer)
        {
            return Encoding.UTF8.GetString(integer.ToByteArray());
        }

    }
}
