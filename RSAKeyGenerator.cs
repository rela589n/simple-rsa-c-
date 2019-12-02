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
        private BigInteger primeLowerBound = BigInteger.Parse("100000000000000000000000000000000000");
        private BigInteger primeUpperBound = BigInteger.Parse("100000000000000000000000000000000000");

        private BigInteger p =  BigInteger.Parse("1090660992520643446103273789680343");
        private BigInteger q = BigInteger.Parse("1162435056374824133712043309728653");

        /*
        private BigInteger p = BigInteger.Parse("12131072439211271897323671531612440428472427633701410925634549312301964373042085619324197365322416866541017057361365214171711713797974299334871062829803541");
        private BigInteger q = BigInteger.Parse("12027524255478748885956220793734512128733387803682075433653899983955179850988797899869146900809131611153346817050832096022160146366346391812470987105415233");
        */
        private BigInteger n;
        private BigInteger phiN;
        private RandomPrimeGenerator primeGenerator;

        public PublicKey publicKey { get; }
        public PrivateKey privateKey { get;  }
        public RSAKeyGenerator()
        {
            this.primeGenerator = new RandomPrimeGenerator();
            this.p = 
            this.n = p * q;
            this.phiN = (p - 1) * (q - 1);
            this.publicKey = this.generatePublicKey();
            this.privateKey = this.generatePrivateKey();
        }

        private BigInteger gcdExtended(BigInteger a, BigInteger b, out BigInteger x, out BigInteger y)
        {
            // Base Case 
            if (a == 0)
            {
                x = 0;
                y = 1;
                return b;
            }

            // To store results of 
            // recursive call 
            BigInteger x1, y1;
            BigInteger gcd = gcdExtended(b % a, a, out x1, out y1);

            // Update x and y using  
            // results of recursive call 
            x = y1 - (b / a) * x1;
            y = x1;

            return gcd;
        }


        private BigInteger gcd(BigInteger a, BigInteger b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                {
                    a %= b;
                }
                else
                {
                    b %= a;
                }
            }

            return a + b;
        }

        // A naive method to find modulor  
        // multiplicative inverse of 'a'  
        // under modulo 'm' 
        private BigInteger modInverse(BigInteger a, BigInteger m)
        {
            a = a % m;
            for (BigInteger x = 1; x < m; ++x)
                if ((a * x) % m == 1)
                    return x;
            return 1;
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

            for (; BigInteger.GreatestCommonDivisor(e, phiN) != 1 && e < phiN; ++e);

            return e;
        }
        
        //attack at dawn
        private PublicKey generatePublicKey()
        {
            return new PublicKey(n, generateE());
        }

        private PrivateKey generatePrivateKey()
        {

            return new PrivateKey(n, Inverse(this.publicKey.E, this.phiN));
            
            /*
            //BigInteger d1, d2;
            BigInteger y, x;

            gcdExtended(phiN, this.publicKey.E, out _, out y); // y === d
            //gcdExtended(this.publicKey.E, phiN, out d1, out d2);
            //gcdExtended(this.publicKey.E, this.phiN, out d1, out d2);
            return new PrivateKey(this.n, y);
            */
        }
    }

    /*
    public class RSA
    {
        public BigInteger publicKey;//публичный ключ
        private BigInteger privateKey;//приватный ключ
        public BigInteger n;

        public RSA(BigInteger p, BigInteger q)//конструктор
        {
            n = n = BigInteger.Multiply(p, q);//считаем n
            BigInteger fi = (p - 1) * (q - 1);//считаем функцию Эйлера

            publicKey = BigInteger.Generate(fi);//генерируем публичный ключ
            while (!BigInteger.IsPrimeMillerRabin(publicKey, 100))
            {
                publicKey = BigInteger.Generate(fi);
            }
            privateKey = publicKey.Inverse(fi);//считаем приватный ключ
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

        public bool IsPrimeMillerRabin(BigInteger n, int s)
        {
            BigInteger pred = 0;
            for (int j = 0; j < s; j++) { BigInteger a = Generate(n); while (a.Equals(pred)) { a = Generate(n); } if (Witness(a, n)) { return false; } }
            return true;
        }

        public static BigInteger Generate(BigInteger n)
        {
            BigInteger maxBigInteger = n - 1;
            BigInteger bigBase = new BigInteger(myBase.ToString());
            Random r = new Random();
            List arr = new List(maxBigInteger.arr.Count);

            bool flag = true;
            for (int i = maxBigInteger.arr.Count - 1; i >= 0; i--)
            {
                int temp;
                if (flag)
                {
                    temp = r.Next(maxBigInteger.arr[i] + 1);
                    flag = maxBigInteger.arr[i] == temp;
                }
                else
                {
                    temp = r.Next(myBase);
                }
                arr.Add(temp);
            }
            arr.Reverse();
            return new BigInteger(arr, true);
        }

        public BigInteger Crypt(BigInteger m)//шифруем
                {
                    return m.Pow(publicKey, n);
                }
        public BigInteger Decrypt(BigInteger c)//дешифруем
        {
            return c.Pow(privateKey, n);
        }
    }
    */
}