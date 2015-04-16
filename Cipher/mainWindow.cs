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
        public mainWindow()
        {
            InitializeComponent(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool isCorrect = false;
            for (int i = 0; i < codedListBox.Items.Count; i++)
            {
                if (codedListBox.Items[i].ToString() == decodedWordOut[i].ToString())
                {
                    isCorrect = true;
                }
                else
                {
                    isCorrect = false;
                    break;
                }
            }
            if (isCorrect == true)
            {
                MessageBox.Show("You got all of the symbols correct!");
            }
            else
            {
                MessageBox.Show("Your guesses are not correct, please try again");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            codedWordDialog.ShowDialog();
            string codedWordFileName = codedWordDialog.FileName;
            if (codedLoaded == false)
            {
                using (StreamReader cwr = new StreamReader(codedWordFileName))
                {
                    string line;
                    while ((line = cwr.ReadLine()) != null)
                    {
                        wordOut.Add(new codedWords(line));
                    }
                }
                codedListBox.Items.AddRange(wordOut.ToArray());
                codedLoaded = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cluesDialog.ShowDialog();
            string cluesFileName = cluesDialog.FileName;
            if (cluesLoaded == false)
            {
                using (StreamReader cr = new StreamReader(cluesFileName))
                {
                    string line;
                    while ((line = cr.ReadLine ()) != null)
                    {
                        clueWordOut.Add(new cluesWords(line));
                    }
                }
                cluesListBox.Items.AddRange(clueWordOut.ToArray());
                cluesLoaded = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            decodedWordDialog.ShowDialog();
            string decodedFileName = decodedWordDialog.FileName;
            if (decodedLoaded == false)
            {
                using (StreamReader dr = new StreamReader(decodedFileName))
                {
                    string line;
                    while ((line = dr.ReadLine()) != null)
                    {
                        decodedWordOut.Add(new decodedWords(line));
                    }
                }
                decodedLoaded = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isPairUsable = true;
            for (int p = 0; p < pairingsListBox.Items.Count; p++)
            {
                if (pairingsListBox.Items[p].ToString().Contains(letterGuess.Text.ToUpper()))
                {
                    MessageBox.Show("You've already used this letter! Please select another letter.");
                    isPairUsable = false;
                    break;
                }
                /*if (pairingsListBox.Items[p].ToString().Contains(symbolGuess.Text))
                {
                    MessageBox.Show("You've already used this symbol! Please select another symbol.");
                    isPairUsable = false;
                    break;
                }*/
            }
            if (isPairUsable == true)
            {
                if (letterGuess.Text != null && symbolGuess.Text != null)
                {
                    pairs.Add(new symbolPair(letter: letterGuess.Text.ToUpper(), code: symbolGuess.Text));
                    pairingsListBox.Items.Clear();
                    pairingsListBox.Items.AddRange(pairs.ToArray());
                    foreach (codedWords w in wordOut)
                    {
                        w.codedKnownPairs = pairs;
                    }
                    codedListBox.Items.Clear();
                    codedListBox.Items.AddRange(wordOut.ToArray());
                }
                else
                {
                    MessageBox.Show("Please enter a letter and a symbol!");
                }
            }
        }

        private void deletePairButton_Click(object sender, EventArgs e)
        {
            pairs.RemoveAt(pairingsListBox.SelectedIndex);
            pairingsListBox.Items.RemoveAt(pairingsListBox.SelectedIndex);
            foreach (codedWords w in wordOut)
            {
                w.codedKnownPairs = pairs;
            }
            codedListBox.Items.Clear();
            codedListBox.Items.AddRange(wordOut.ToArray());

        }
    }
}
