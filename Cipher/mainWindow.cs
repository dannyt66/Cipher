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
        public List<words> wordOut = new List<words>();
        string codedWordFileName;
        bool loaded = false;
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
            codedWordFileName = codedWordDialog.FileName;
            if (loaded == false)
            {
                using (StreamReader cwr = new StreamReader(codedWordFileName))
                {
                    string line;
                    while ((line = cwr.ReadLine()) != null)
                    {
                        wordOut.Add(new words(line));
                    }
                }
                codedListBox.Items.AddRange(wordOut.ToArray());
                loaded = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cluesDialog.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            decodedWordDialog.ShowDialog();
        }
    }
}
