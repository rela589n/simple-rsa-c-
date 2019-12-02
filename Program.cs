using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace RSA
{
    class Program
    {
        private int menu()
        {
            try { 
                Console.WriteLine("1 - Encrypt. 2 - Decrypt. 3 - Generate keys. 4 - Exit.");

                return int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Input error!. Please, retry.\n");
                return menu();
            }
        }

        private CommandResolver resolver;
        public Program()
        {
            //this.rsa = new RSAKeyGenerator();
            this.resolver = new CommandResolver();
        }
        

        public void run()
        {
            try
            {
                Command cmd = resolver.getCommand(menu());
                cmd.execute();
            }
            catch (CommandNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            run();
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.run();
            Console.ReadLine();
        }
    }
}
