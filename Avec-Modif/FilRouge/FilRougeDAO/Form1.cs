using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FilRougeDAO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();

            Hide();

            f3.ShowDialog();

            Show();


            
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 g = new Form2();

            Hide();
            g.ShowDialog();
            Show();
        }
    }
}
