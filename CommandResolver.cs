using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA
{
    class CommandResolver
    {
        private const int COMMAND_ENCRYPT = 1;
        private const int COMMAND_DECRYPT = 2;
        private const int COMMAND_GENERATE = 3;
        private const int COMMAND_EXIT = 4;
        public Command getCommand(int status)
        {
            switch (status)
            {
                case COMMAND_ENCRYPT:

                    return new EncryptCommand();
                case COMMAND_DECRYPT:

                    return new DecryptCommand();
                case COMMAND_EXIT:

                    return new ExitCommand();

                case COMMAND_GENERATE:

                    return new RSAKeyGeneratorCommand();
                default:
                    throw new CommandNotFoundException($"Command with status {status} not found!");
            }
        }
    }
}
