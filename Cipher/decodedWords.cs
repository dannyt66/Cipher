using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cipher
{
    public class decodedWords
    {
        //Set the string for word input
        public string wordIn;
        //Allow the class to use the symbol pairings
        public List<symbolPair> decodedKnownPairs = new List<symbolPair>();
        //Declare that a word should be passed to the class
        public decodedWords(string word)
        {
            //Set the passed word inside the class
            wordIn = word;
        }
        //Declare a new ToString() method
        public override string ToString()
        {
            //Return the decoded word
            return DecodedWord();
        }
        //Decode the word
        public string DecodedWord()
        {
            //Set the word to be modified to be the inputted word
            string return_word = wordIn;
            //Loop through each known symbol pairing
            foreach(symbolPair s in decodedKnownPairs)
            {
                //Replace the symbol in the word with the matching letter
                return_word = return_word.Replace(s.Code, s.Letter);
            }
            //Return the decoded word
            return return_word;
        }
    }
}
