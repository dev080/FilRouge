﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FilRougeDAO
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand requete;
            SqlDataReader resultat = null;

            if (listBox1.SelectedItem != null)
            {
                // met dans label8 la valeur de la réduction du client
                SqlConnection connect = new SqlConnection("server=(local); integrated security = true; database = FilRouge_essai_modif");
                connect.Open();

                if (listBox1.SelectedItem.GetType() == typeof(USState))
                {
                    USState d = (USState)listBox1.SelectedItem;

                    //  d = listBox1.SelectedValue;
                    //  MessageBox.Show(listBox1.SelectedValue.ToString());


                    requete = new SqlCommand("select CoeffClient from client where IdClient=" + d.ShortName, connect);

                    try { resultat = requete.ExecuteReader(); }
                    catch (Exception r)
                    { MessageBox.Show(r.Message); }

                    while (resultat.Read())
                    {
                        label8.Text = (resultat["CoeffClient"].ToString());

                    }
                    resultat.Close();


                    //place l'indice du trackbar
                    requete = new SqlCommand("select Reduction from Client where Idclient=" + d.ShortName + "", connect);
                    resultat = requete.ExecuteReader();
                    while (resultat.Read())
                    {
                        trackBar1.Value = Int32.Parse((resultat["Reduction"].ToString()));

                    }
                    resultat.Close();
                }
                connect.Close();


            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            //USState d = (USState)listBox1.SelectedValue;
            int d = Int32.Parse(listBox1.SelectedValue.ToString());

         //   int d2 = Int32.Parse(d.ShortName);


            //USState d2 = (USState)listBox1.SelectedValue;


         //   MessageBox.Show(" index client = " + listBox1.SelectedValue + " index produit " + listBox2.SelectedValue);


            SqlConnection connect = new SqlConnection("server=(local); integrated security = true; database = FilRouge_essai_modif");

            connect.Open();

            SqlCommand requete = new SqlCommand(@"INSERT INTO commande (EtatCommande,DateCommande,MontantCommande,DatePaiement,Idclient,IdFacture )
VALUES('saisie', @date, @montant, null, @id, null) ", connect);

            DateTime d3= DateTime.Now;

            requete.Parameters.AddWithValue("@date",d3);
            requete.Parameters.AddWithValue("@montant",Decimal.Parse(label6.Text));
            requete.Parameters.AddWithValue("@id",d);

            requete.ExecuteNonQuery();

            SqlCommand requete2 = new SqlCommand(@"select max(idcommande) from commande", connect);

            Int32 position=(Int32)(requete2.ExecuteScalar());

            MessageBox.Show(" dernier index vaut: "+position);


            SqlCommand requete3 = new SqlCommand(@"INSERT INTO composer1 (QuantiteProd,IdProduit,IdCommande,)
VALUES(@qte, @idp,@idc)", connect);

            int d2= Int32.Parse(listBox2.SelectedValue.ToString());

            requete.Parameters.AddWithValue("@qte", Int32.Parse(textBox1.Text));
            requete.Parameters.AddWithValue("@idp", d2);
            requete.Parameters.AddWithValue("@idc", position);



            connect.Close();

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //enregistre le nouveau montant de la réduction
            SqlConnection connect = new SqlConnection("server=(local); integrated security = true; database = FilRouge_essai_modif");
            connect.Open();
            SqlCommand requete = new SqlCommand("update Client set reduction=" + trackBar1.Value + " where IdClient='" + listBox1.SelectedValue + "'", connect);

            requete.ExecuteNonQuery();

            connect.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            Form6 z = new Form6();
            z.ShowDialog();
            Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            //affiche la liste déroulante des clients
            SqlConnection connect = new SqlConnection("server=(local); integrated security = true; database = FilRouge_essai_modif");
            connect.Open();

            SqlCommand requete = new SqlCommand("select * from client", connect);
            SqlDataReader resultat = requete.ExecuteReader();

            ArrayList USStates = new ArrayList();

            while (resultat.Read())
            {
                //listBox1.Items.Add();
                USStates.Add(new USState(resultat["IdClient"].ToString(), resultat["NomClient"].ToString()));

            }

            listBox1.DataSource = USStates;
            listBox1.DisplayMember = "LongName";
            listBox1.ValueMember = "ShortName";

            resultat.Close();





            //affiche la liste déroulante des instruments
            SqlCommand requete2 = new SqlCommand("select * from produit", connect);
            resultat = requete2.ExecuteReader();

            ArrayList USStates2 = new ArrayList();

            while (resultat.Read())
            {
                //listBox1.Items.Add();
                USStates2.Add(new USState(resultat["IdProduit"].ToString(), resultat["NomProdCourt"].ToString()));

            }




            listBox2.DisplayMember = "LongName";
            listBox2.ValueMember = "ShortName";
            listBox2.DataSource = USStates2;

            resultat.Close();

            connect.Close();


        }

        public class USState
        {
            private string myID;
            private string mycliName;

            public USState(string strShortName, string strLongName)
            {

                this.myID = strShortName;
                this.mycliName = strLongName;
            }

            public string ShortName
            {
                get
                {
                    return myID;
                }
            }

            public string LongName
            {

                get
                {
                    return mycliName;
                }
            }

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

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form4 z = new Form4();
            z.ShowDialog();
            Show();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {

                double total = double.Parse(textBox1.Text) * double.Parse(textBox2.Text);

                double reduction = double.Parse(label8.Text) + trackBar1.Value;
                MessageBox.Show("la somme des deux pourcentages =" + reduction);

                reduction = reduction / 100;

                MessageBox.Show("la somme des deux pourcentages =" + reduction);

                double temp = (total) * (reduction);

                MessageBox.Show("temp vaut " + temp);

                label6.Text = (total - temp).ToString();
            }
            else
            {
                MessageBox.Show("Choisissez une quantité");

            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection("server=(local); integrated security = true; database = FilRouge_essai_modif");
            connect.Open();
            USState test = (USState)listBox2.SelectedItem;



            SqlCommand requete = new SqlCommand("select PrixHT_Prod from produit where IdProduit =" + test.ShortName, connect);
            SqlDataReader resultat = requete.ExecuteReader();
            if (resultat.Read())
            {
                textBox2.Text = resultat["prixHT_Prod"].ToString();


            }
            resultat.Close();

            connect.Close();



        }

    }
}
