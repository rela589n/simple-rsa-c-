using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA
{
    class ExitCommand : Command
    {
        protected override void doExecute()
        {
            System.Environment.Exit(0);
        }
    }
}
