using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Cipher
{
    public partial class mainWindow : Form
    {
        public List<symbolPair> pairs = new List<symbolPair>();
        public List<codedWords> wordOut = new List<codedWords>();
        public List<cluesWords> clueWordOut = new List<cluesWords>();
        public List<decodedWords> decodedWordOut = new List<decodedWords>();
        bool codedLoaded = false;
        bool cluesLoaded = false;
        bool decodedLoaded = false;
        //Initialise array for symbol frequency counter
        int[] frequencyCounter = new int[128];
        public mainWindow()
        {
            InitializeComponent(); 
        }
        //Check guesses once user has clicked the check button
        private void button2_Click(object sender, EventArgs e)
        {
            //Declare the boolean for checking if correct
            bool isCorrect = false;
            //Loop through the user's decoded words
            for (int i = 0; i < codedListBox.Items.Count; i++)
            {
                //Check each word against the loaded decoded words file
                if (codedListBox.Items[i].ToString() == decodedWordOut[i].ToString())
                {
                    //If they are correct, set the boolean to true
                    isCorrect = true;
                }
                else
                {
                    //If incorrect, set to false
                    isCorrect = false;
                    //Exit the loop as the user has not got their guesses correct - no need to check others
                    break;
                }
            }
            //Display a message based on if the user was correct
            if (isCorrect == true)
            {
                //The message for them being correct
                MessageBox.Show("You got all of the symbols correct!");
            }
            else
            {
                //The message for them being incorrect
                MessageBox.Show("Your guesses are not correct, please try again");
            }
        }
        //Load the coded words
        private void button3_Click(object sender, EventArgs e)
        {
            //Open the relevant open file dialog
            codedWordDialog.ShowDialog();
            string codedWordFileName = codedWordDialog.FileName;
            //Make sure they have not already loaded a file
            if (codedLoaded == false)
            {
                //Read the file
                using (StreamReader cwr = new StreamReader(codedWordFileName))
                {
                    string line;
                    //Add each line of the file to the array
                    while ((line = cwr.ReadLine()) != null)
                    {
                        wordOut.Add(new codedWords(line));
                    }
                }
                //Add the contents of the array to the list box
                codedListBox.Items.AddRange(wordOut.ToArray());
                //Set the file loaded to true
                codedLoaded = true;
                //Loop through the words in the list box
                for (int i = 0; i < wordOut.Count; i++)
                {
                    //Loop through the characters in the words
                    for (int c = 0; c < wordOut[i].ToString().Length; c++)
                    {
                        //Find the ASCII value of each character
                        int asciiFind = (int)wordOut[i].ToString()[c];
                        //Add one to the frequency array position for the ASCII value for each character
                        frequencyCounter[asciiFind]++;
                    }
                }
                //Loop through the frequency array
                for (int i = 0; i <= 127; i++)
                {
                    //Check the character has occured at least once
                    if (frequencyCounter[i] >= 1)
                    {
                        //Decode the position back into a character, and print the number of times it occurs
                        frequencyList.Items.Add(((char)i) + " = " + frequencyCounter[i]);
                    }
                }
            }
        }
        //Load the clues
        private void button4_Click(object sender, EventArgs e)
        {
            //Open the relavent open file dialog
            cluesDialog.ShowDialog();
            string cluesFileName = cluesDialog.FileName;
            //Check the user has not already loaded the clues file
            if (cluesLoaded == false)
            {
                //Read the clues file
                using (StreamReader cr = new StreamReader(cluesFileName))
                {
                    string line;
                    //Add each line from the clues file to the array
                    while ((line = cr.ReadLine ()) != null)
                    {
                        clueWordOut.Add(new cluesWords(line));
                    }
                }
                //Copy the contents of the array to the list box
                cluesListBox.Items.AddRange(clueWordOut.ToArray());
                //Set the file loaded to true
                cluesLoaded = true;
            }
        }
        //Load the decoded words
        private void button5_Click(object sender, EventArgs e)
        {
            //Show the relavent open file dialog
            decodedWordDialog.ShowDialog();
            string decodedFileName = decodedWordDialog.FileName;
            //Make sure the decoded words have not already been loaded
            if (decodedLoaded == false)
            {
                //Read the selected file
                using (StreamReader dr = new StreamReader(decodedFileName))
                {
                    string line;
                    //Add each line from the file to the array
                    while ((line = dr.ReadLine()) != null)
                    {
                        decodedWordOut.Add(new decodedWords(line));
                    }
                }
                //Set the file loaded to true
                decodedLoaded = true;
            }
        }
        //Button to add a pair
        private void button1_Click(object sender, EventArgs e)
        {
            //Initialise the boolean to check if a pair has been used. True as if the loop does not set it to false, it the pair has to be usable
            bool isPairUsable = true;
            //Loop through the current pairings list box
            for (int p = 0; p < pairingsListBox.Items.Count; p++)
            {
                //Check that the letter that was inputted hasn't already been used
                if (pairingsListBox.Items[p].ToString().Contains(letterGuess.Text.ToUpper()))
                {
                    //Inform the player they can't use this letter
                    MessageBox.Show("You've already used this letter! Please select another letter.");
                    //Set that the pair cannot be used
                    isPairUsable = false;
                    //Exit the loop as a matching letter has been found
                    break;
                }
                //Only check the first character to ensure - can be used
                string symbolCheck = pairingsListBox.Items[p].ToString().Remove(2, 6);
                //Check that the symbol inputted has not already been used
                if (symbolCheck.Contains(symbolGuess.Text))
                {
                    //Inform the player that they can't use this symbol
                    MessageBox.Show("You've already used this symbol! Please select another symbol.");
                    //Set that the pair cannot be used
                    isPairUsable = false;
                    //Exit the loop as a matching symbol has been found
                    break;
                }
            }
            //Make sure the pair is usable before adding it
            if (isPairUsable == true)
            {
                //Make sure the boxes are not empty
                if (letterGuess.Text.Trim().Length != 0 && symbolGuess.Text.Trim().Length != 0)
                {
                    //Call the symbolPair class to create the pairing
                    pairs.Add(new symbolPair(letter: letterGuess.Text.ToUpper(), code: symbolGuess.Text));
                    //Clear the pairs list box
                    pairingsListBox.Items.Clear();
                    //Readd all the items with the new pair included
                    pairingsListBox.Items.AddRange(pairs.ToArray());
                    //Loop through all the coded words
                    foreach (codedWords w in wordOut)
                    {
                        //Replace the symbol with the letter in the coded words
                        w.codedKnownPairs = pairs;
                    }
                    //Clear the coded words list box
                    codedListBox.Items.Clear();
                    //Add all the items with the new symbol replaced
                    codedListBox.Items.AddRange(wordOut.ToArray());
                    //Reset the input boxes to blank
                    letterGuess.Text = "";
                    symbolGuess.Text = "";
                }
                //If either box is empty when the guess button is clicked
                else
                {
                    //Inform the user they have to fill both boxes
                    MessageBox.Show("Please enter a letter and a symbol!");
                }
            }
        }
        //Delete pair button clicked
        private void deletePairButton_Click(object sender, EventArgs e)
        {
            //Remove the selected pair from the array generated by the pairs class
            pairs.RemoveAt(pairingsListBox.SelectedIndex);
            //Remove the selected pair from the list box
            pairingsListBox.Items.RemoveAt(pairingsListBox.SelectedIndex);
            //Loop through the words in the coded words box
            foreach (codedWords w in wordOut)
            {
                //Replace the letter in the deleted pair with the symbol
                w.codedKnownPairs = pairs;
            }
            //Clear the coded words box
            codedListBox.Items.Clear();
            //Add all the items again with the deleted pair's letter replaced by the symbol
            codedListBox.Items.AddRange(wordOut.ToArray());

        }
    }
}
