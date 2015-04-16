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
        bool codedLoaded = false;
        bool cluesLoaded = false;
        public mainWindow()
        {
            InitializeComponent(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {

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
                        clueWordOut.Add(new cluesWords(line));
                    }
                }
                codedListBox.Items.AddRange(clueWordOut.ToArray());
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
                        wordOut.Add(new codedWords(line));
                    }
                }
                pairingsListBox.Items.AddRange(wordOut.ToArray());
                cluesLoaded = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            decodedWordDialog.ShowDialog();
        }
    }
}
