using FilRougeDAO.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilRougeDAO
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client c = new Client();

            c.IdClient = Int32.Parse( label12.Text);
            c.civiliteclient = listBox1.SelectedItem.ToString();
            c.Nomclient = textBox1.Text;
            c.PrenomClient = textBox2.Text;
            c.CategorieClient = listBox4.SelectedItem.ToString();
            c.AdrlivraisonClient = textBox4.Text;
            c.AdrFacturationClient = textBox5.Text;
            c.Coeffclient = Int32.Parse(textBox6.Text);
            c.Reduction = Int32.Parse(textBox7.Text);
            c.Idcommercial = listBox2.SelectedIndex + 1; //a revoir

            ClientDAO c2 = new ClientDAO(Properties.Settings.Default.chaine);
            c2.update(c);

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            CommercialDAO g = new CommercialDAO(Properties.Settings.Default.chaine);
            listBox2.DataSource = g.ListCommer();
            listBox2.DisplayMember = "NomCommercial";




            ClientDAO f2 = new ClientDAO(Properties.Settings.Default.chaine);

            listBox3.DataSource = f2.ListCli();
            listBox3.DisplayMember = "NomClient";
            // listBox3.SelectedIndex = -1;




        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Client c = new Client();


            c = (Client)listBox3.SelectedItem;

            label12.Text = c.IdClient.ToString();
            listBox1.SelectedItem = c.civiliteclient;
            textBox1.Text = c.Nomclient;
            textBox2.Text = c.PrenomClient;
            listBox4.SelectedItem = c.CategorieClient;
            textBox4.Text = c.AdrlivraisonClient;
            textBox5.Text = c.AdrFacturationClient;
            textBox6.Text = c.Coeffclient.ToString();
            textBox7.Text = c.Reduction.ToString();
            listBox2.SelectedIndex = c.Idcommercial - 1; //a voir...

        }
    }
}
