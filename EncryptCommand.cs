using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RSA
{
    class EncryptCommand : Command
    {
        private PublicKey key;
        private RSAEncryptor encryptor;
        public void init()
        {
            initPublicKey();
            this.encryptor = new RSAEncryptor(key, new RSAHelper());
        }

        public void initPublicKey()
        {
            try
            {
                Console.WriteLine("To encrypt you must have public key.");
                Console.Write("Enter n: ");
                BigInteger n = BigInteger.Parse(Console.ReadLine());

                Console.Write("Enter e: ");
                BigInteger e = BigInteger.Parse(Console.ReadLine());

                this.key = new PublicKey(n, e);
            }
            catch (Exception)
            {
                Console.WriteLine("Something wrong! Please, retry.\n");
                initPublicKey();
            }
        }
        protected override void doExecute()
        {
            init();
            Console.WriteLine("Enter message to encrypt: ");
            String message = Console.ReadLine();

            Console.WriteLine("Encrypted message:\n" + encryptor.encrypt(message) + "\n");
        }
    }
}
