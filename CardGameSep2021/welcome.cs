using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGameSep2021
{
    public partial class welcome : Form
    {
       
        public welcome()
        {
            InitializeComponent();
        }

        private void welcome_Load(object sender, EventArgs e)
        {
            label3.Visible = false;
          

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
               
                
                new Form1(textBox1.Text).Show();
            }
            else {
               
                label3.Text = "You can't leave this field empty";
                label3.Visible = true;
            }
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            label3.Visible = false;
        }
    }
}
