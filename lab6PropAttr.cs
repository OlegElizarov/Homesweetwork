using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    public class PropAttr : Attribute
    {
        public static string Description;
        public PropAttr(string s)
        {
            Description = s;
        }
    }
}
