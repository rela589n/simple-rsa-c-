using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace RSA
{
    class PublicKey
    {
        public BigInteger N { get; }
        public BigInteger E { get; }
        public PublicKey(BigInteger n, BigInteger e)
        {
            this.N = n;
            this.E = e;
        }
    }
}
