using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace RSA
{
    class PrivateKey
    {
        public BigInteger D { get; }
        public BigInteger N { get; }
        public PrivateKey(BigInteger n, BigInteger d)
        {
            this.N = n;
            this.D = d;
        }
    }
}
