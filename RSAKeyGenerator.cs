using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace RSA
{
    class RSAKeyGenerator
    {
        private BigInteger primeLowerBound = BigInteger.Parse("100000000000000000000000000000000000000000000000000000000000000000000000"); // 10 ** 71
        private BigInteger primeUpperBound = BigInteger.Parse("999999999999999999999999999999999999999999999999999999999999999999999999999");

        private BigInteger  n, 
                            p,
                            q,
                            phiN;

        private RandomPrimeGenerator primeGenerator;

        public PublicKey publicKey { get; }
        public PrivateKey privateKey { get;  }
        public RSAKeyGenerator()
        {
            this.primeGenerator = new RandomPrimeGenerator();
            this.p = primeGenerator.nextPrime(primeLowerBound, primeUpperBound);
            this.q = primeGenerator.nextPrime(primeLowerBound, primeUpperBound);

            this.n = p * q;
            this.phiN = (p - 1) * (q - 1);

            this.publicKey = this.generatePublicKey();
            this.privateKey = this.generatePrivateKey();
        }

        public BigInteger Inverse(BigInteger a, BigInteger n)
        {
            BigInteger b = n, x = 0, d = 1;
            while (a > 0)
            {
                BigInteger q = b / a;
                BigInteger y = a;
                a = b % a;
                b = y;
                y = d;
                d = x - q * d;
                x = y;
            }
            x = x % n;
            if (x < 0)
            {
                x = (x + n) % n;
            }
            return x;
        }

        private BigInteger generateE()
        {
            BigInteger e = 3;

            for (; BigInteger.GreatestCommonDivisor(e, phiN) != 1 && e < phiN; e += 2);

            return e;
        }
        
        private PublicKey generatePublicKey()
        {
            return new PublicKey(n, generateE());
        }

        private PrivateKey generatePrivateKey()
        {

            return new PrivateKey(n, Inverse(this.publicKey.E, this.phiN));
        }
    }
}