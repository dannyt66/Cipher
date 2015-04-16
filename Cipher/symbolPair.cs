using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cipher
{
    public class symbolPair
    {
        public string Letter { get; set; }
        public string Code { get; set; }
        
        public symbolPair(string letter, string code)
        {
            Letter = letter;
            Code = code;
        }
        public override string ToString()
        {
            return Code + " -> " + Letter;
        }
    }
}
