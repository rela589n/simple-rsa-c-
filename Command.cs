using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA
{
    abstract class Command
    {
        private RSAHelper converter;

        public Command()
        {
            this.converter = new RSAHelper();
        }
        public void execute()
        {
            this.doExecute();
        }

        protected abstract void doExecute();
    }
}
