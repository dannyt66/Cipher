using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cipher
{
    public class cluesWords
    {
        //Set the string for a word input
        public string wordIn;
        //Allow the class to use the known symbol pairings
        public List<symbolPair> knownPairs = new List<symbolPair>();
        //Set that the class should have a word passed to it
        public cluesWords(string word)
        {
            //Set the passed word to be the value of the word input
            wordIn = word;
        }
        //Create a new ToString() method
        public override string ToString()
        {
            //Return the decoded word
            return clueDecodedWord();
        }
        //Decode the word
        public string clueDecodedWord()
        {
            //Set the word to be modified to be the inputted word
            string return_word = wordIn;
            //Loop through the known symbol pairings
            foreach(symbolPair s in knownPairs)
            {
                //Replace the symbol with the letter in the current word
                return_word = return_word.Replace(s.Code, s.Letter);
            }
            //Return the decoded word
            return return_word;
        }
    }
}
