﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA
{
    class CommandNotFoundException : Exception
    {
        public CommandNotFoundException(String mesage) : base(mesage)
        {

        }
    }
}
