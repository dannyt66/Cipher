using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cipher
{
    public class symbolPair
    {
        //Set up a letter and a code that can be retrieved and set
        public string Letter { get; set; }
        public string Code { get; set; }
        //Set up the class, allowing a letter and a code to be passed to it
        public symbolPair(string letter, string code)
        {
            //Set the letter and the code to be those that were passed to the class
            Letter = letter;
            Code = code;
        }
        //Create a new ToString() method
        public override string ToString()
        {
            //Return the pair in the format "Code -> Letter"
            return Code + " -> " + Letter;
        }
    }
}
