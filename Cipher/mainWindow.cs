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
            for (int i = 0; i <= codedListBox.Items.Count; i++)
            {

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
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (letterGuess.Text != null && symbolGuess.Text != null)
            {
                pairs.Add(new symbolPair(letter: letterGuess.Text, code: symbolGuess.Text));
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
