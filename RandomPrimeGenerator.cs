using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace RSA
{
    class RandomPrimeGenerator
    {
        private RandomBigInteger rnd;
        public RandomPrimeGenerator()
        {
            rnd = new RandomBigInteger();
        }

        public BigInteger nextPrime(BigInteger left, BigInteger right)
        {
            BigInteger probablePrime;

            do
            {
                probablePrime = rnd.NextBigInteger(left, right);
            }
            while (!PrimeExtensions.IsProbablyPrime(probablePrime));

            return probablePrime;
        }   
    }
}
