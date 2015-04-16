using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cipher
{
    public class codedWords
    {
        public string WordIn;
        public List<symbolPair> clueKnownPairs = new List<symbolPair>();
        public codedWords(string word)
        {
            WordIn = word;
        }
        public override string ToString()
        {
            return DecodedWord();
        }
        public string DecodedWord()
        {
            string return_word = WordIn;
            foreach(symbolPair s in clueKnownPairs)
            {
                return_word = return_word.Replace(s.Code, s.Letter);
            }
            return return_word;
        }
    }
}
