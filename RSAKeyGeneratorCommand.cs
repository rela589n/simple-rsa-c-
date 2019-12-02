using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace RSA
{
    class RSAKeyGeneratorCommand : Command
    {
        private RSAKeyGenerator keyGenerator;
        private void init()
        {
            this.keyGenerator = new RSAKeyGenerator();
        }

        private BigInteger inputK()
        {
            try
            {
                Console.WriteLine("Enter random decimal integer value: ");
                String _k = Console.ReadLine();
                BigInteger k = BigInteger.Parse(_k);
                return k;
            }
            catch (Exception)
            {
                Console.WriteLine("Input is not decimal integer.");
                return inputK();
            }
        }

        private void printPublicKey(PublicKey publicKey)
        {
            Console.WriteLine("Public key: ");
            Console.WriteLine("\tn: " + publicKey.N);
            Console.WriteLine("\te: " + publicKey.E + "\n");
        }

        private void printPrivateKey(PrivateKey privateKey)
        {
            Console.WriteLine("Private key: ");
            Console.WriteLine("\tn: " + privateKey.N);
            Console.WriteLine("\td: " + privateKey.D + "\n");
        }
        protected override void doExecute()
        {
            this.init();

            printPublicKey(this.keyGenerator.publicKey);
            printPrivateKey(this.keyGenerator.privateKey);
        }
    }
}
