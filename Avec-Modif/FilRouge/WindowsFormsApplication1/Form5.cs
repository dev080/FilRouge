using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // met dans label8 la valeur de la réduction du client
            SqlConnection connect = new SqlConnection("server=(local); integrated security = true; database = FilRouge_essai_modif");
            connect.Open();

            SqlCommand requete = new SqlCommand("select CoeffClient from client where NomClient='" + listBox1.SelectedItem + "'", connect);

            SqlDataReader resultat = requete.ExecuteReader();
            while (resultat.Read())
            {
                label8.Text = (resultat["CoeffClient"].ToString());

            }
            resultat.Close();


            //place l'indice du trackbar
            requete = new SqlCommand("select Reduction from Client where Nomclient='" + listBox1.SelectedItem + "'", connect);
            resultat = requete.ExecuteReader();
            while (resultat.Read())
            {
                trackBar1.Value = Int32.Parse((resultat["Reduction"].ToString()));

            }
            resultat.Close();

            connect.Close();




        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //enregistre le nouveau montant de la réduction
            SqlConnection connect = new SqlConnection("server=(local); integrated security = true; database = FilRouge_essai_modif");
            connect.Open();
            SqlCommand requete = new SqlCommand("update Client set reduction=" + trackBar1.Value + " where NomClient='" + listBox1.SelectedItem + "'", connect);

            requete.ExecuteNonQuery();

            connect.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

            //affiche la liste déroulante des clients
            SqlConnection connect = new SqlConnection("server=(local); integrated security = true; database = FilRouge_essai_modif");
            connect.Open();

            SqlCommand requete = new SqlCommand("select * from client", connect);
            SqlDataReader resultat = requete.ExecuteReader();
            while (resultat.Read())
            {
                listBox1.Items.Add(resultat["NomClient"].ToString());

            }
            resultat.Close();


            //affiche la liste déroulante des instruments
            requete = new SqlCommand("select * from produit", connect);
            resultat = requete.ExecuteReader();
            while (resultat.Read())
            {
                listBox2.Items.Add(resultat["NomProdCourt"].ToString());

            }
            resultat.Close();

            connect.Close();





        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                MessageBox.Show("Il faut rentrer un nombre");
            }
            //else
            //{
            //    //test du stock
                
            //    SqlConnection connect = new SqlConnection("server=(local); integrated security = true; database = FilRouge_essai_modif");
            //    connect.Open();
            //    SqlCommand requete = new SqlCommand("select StockProduit from produit", connect);
            //    SqlDataReader resultat = requete.ExecuteReader();
            //    while (resultat.Read())
            //    {
            //        e.Equals(resultat["StockProduit"].ToString());


            //    }
            //    //MessageBox.Show("Test du stock");

            //}
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
