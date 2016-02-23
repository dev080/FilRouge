using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FilRougeDAO.DAO;

namespace FilRougeDAO
{
    public partial class Form4: Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            CommercialDAO f = new CommercialDAO(Properties.Settings.Default.chaine);

            listBox2.DataSource=f.ListCommer();
            listBox2.DisplayMember = "Nomcommercial";
            listBox2.ValueMember = "Idcommercial";

            ClientDAO f2 = new ClientDAO(Properties.Settings.Default.chaine);

            listBox3.DataSource = f2.ListCli();
            listBox3.DisplayMember = "NomClient";





        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
                //ajout

                Client d = new Client();
                ClientDAO d2 = new ClientDAO(Properties.Settings.Default.chaine);

                d.civiliteclient = listBox1.SelectedItem.ToString();
                d.Nomclient = textBox1.Text;
                d.PrenomClient = textBox2.Text;
                d.CategorieClient = listBox4.SelectedItem.ToString();
                d.AdrlivraisonClient = textBox4.Text;
                d.AdrFacturationClient = textBox5.Text;
                d.Coeffclient = Int32.Parse(textBox6.Text);
                d.Reduction = Int32.Parse(textBox7.Text);
                d.Idcommercial = Int32.Parse(listBox2.SelectedValue.ToString());




                d2.ajouter(d);

                listBox1.SelectedIndex = -1;
                textBox1.Text = "";
                textBox2.Text = "";
                listBox4.SelectedIndex = -1;
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                listBox2.SelectedIndex = -1;

            
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
