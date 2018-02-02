using NetCoreIservice;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreService
{
    public class CeShi : ICeShi
    {
        public string Show()
        {
            return "ceshi123";
        }
    }
    public class CeShi1 : ICeShi1
    {
        public int Show()
        {
            return 45679;
        }
    }
}
