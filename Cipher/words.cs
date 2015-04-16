using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cipher
{
    public class words
    {
        public string wordIn;
        public List<symbolPair> knownPairs = new List<symbolPair>();
        public words(string word)
        {
            wordIn = word;
        }
        public override string ToString()
        {
            return DecodedWord();
        }
        public string DecodedWord()
        {
            string return_word = wordIn;
            foreach(symbolPair s in knownPairs)
            {
                return_word = return_word.Replace(s.Code, s.Letter);
            }
            return return_word;
        }
    }
}
