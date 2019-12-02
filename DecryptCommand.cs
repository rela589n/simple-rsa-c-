using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace RSA
{
    class DecryptCommand : Command
    {
        private RSADecryptor decryptor;
        private PrivateKey key;
        private void init()
        {
            initPrivateKey();
            this.decryptor = new RSADecryptor(this.key, new RSAHelper());
        }

        public void initPrivateKey()
        {
            try
            {
                Console.WriteLine("To decrypt you must have private key.");
                Console.Write("Enter n: ");
                BigInteger n = BigInteger.Parse(Console.ReadLine());

                Console.Write("Enter d: ");
                BigInteger d = BigInteger.Parse(Console.ReadLine());

                this.key = new PrivateKey(n, d);
            }
            catch (Exception)
            {
                Console.WriteLine("Something wrong! Please, retry.\n");
                initPrivateKey();
            }
        }

        public BigInteger getEncrypted()
        {
            try
            {
                Console.WriteLine("Enter encrypted message to decrypt: ");
                String message = Console.ReadLine();
                return BigInteger.Parse(message);
            }
            catch (Exception)
            {
                Console.WriteLine("Message must contain a decimal integer value. \nYou should probably retry...");
                return getEncrypted();
            }
        }

        protected override void doExecute()
        {
            init();

            Console.WriteLine("Decrypted message:\n" + decryptor.decrypt(getEncrypted()) + "\n");
        }
    }
}
