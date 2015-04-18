using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cipher
{
    public class codedWords
    {
        //The string for the word that was inputted from the text file
        public string WordIn;
        //Allow the class to replace symbols with letters
        public List<symbolPair> codedKnownPairs = new List<symbolPair>();
        public codedWords(string word)
        {
            //Set that a word will be passed to the class upon calling
            WordIn = word;
        }
        //Create a new ToString() method
        public override string ToString()
        {
            //Return the decoded word from the class
            return DecodedWord();
        }
        //Create the decoded word
        public string DecodedWord()
        {
            //Set the initial returned word
            string return_word = WordIn;
            //Loop through each symbol pair
            foreach(symbolPair s in codedKnownPairs)
            {
                //Replace the symbol with the letter inside the symbol pair and set this to the returned word
                return_word = return_word.Replace(s.Code, s.Letter);
            }
            //Return the word with the symbols changed into letters
            return return_word;
        }
    }
}
