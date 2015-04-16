using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cipher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            codedWordDialog.ShowDialog();
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
