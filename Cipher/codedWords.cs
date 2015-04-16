using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cipher
{
    public class codedWords
    {
        public string clueWordIn;
        public List<symbolPair> clueKnownPairs = new List<symbolPair>();
        public codedWords(string word)
        {
            clueWordIn = word;
        }
        public override string ToString()
        {
            return clueDecodedWord();
        }
        public string clueDecodedWord()
        {
            string return_word = clueWordIn;
            foreach(symbolPair s in clueKnownPairs)
            {
                return_word = return_word.Replace(s.Code, s.Letter);
            }
            return return_word;
        }
    }
}
