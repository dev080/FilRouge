using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'filRouge_essai_modifDataSet.Rubrique'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
            //this.rubriqueTableAdapter.Fill(this.filRouge_essai_modifDataSet.Rubrique);

            SqlConnection connect = new SqlConnection("server=(local); integrated security = true; database = FilRouge_essai_modif");
            connect.Open();
            SqlCommand requete = new SqlCommand("select * from rubrique", connect);
            SqlDataReader resultat = requete.ExecuteReader();
            while (resultat.Read())
            {
                listBox1.Items.Add(resultat["NomRubrique"].ToString());

            }
            resultat.Close();
            connect.Close();


        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox3.Items.Clear();

            SqlConnection connect = new SqlConnection("server=(local); integrated security = true; database = FilRouge_essai_modif");
            connect.Open();
            SqlCommand requete = new SqlCommand("select * from produit join SousRubrique on produit.IdSousRubrique = SousRubrique.IdSousRubrique where NomSousRubrique = '"+ listBox2.SelectedItem+"'", connect);
            SqlDataReader resultat = requete.ExecuteReader();
            while (resultat.Read())
            {
                //FileStream fs = new FileStream(@"C:\Users\stagiaire\Dropbox\FilRouge\Avec-Modif\Image\"+resultat["ImageProd"].ToString()+"", FileMode.Open);
                //pictureBox1.Image = Image.FromStream(fs);
                //fs.Close();
                
                listBox3.Items.Add(resultat["NomProdCourt"].ToString()/*+ " " + resultat["NomProdLong"].ToString()+" "+ resultat["ImageProd"].ToString()*/);

            }
            resultat.Close();
            connect.Close();


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();

            SqlConnection connect = new SqlConnection("server=(local); integrated security = true; database = FilRouge_essai_modif");
            connect.Open();
            SqlCommand requete = new SqlCommand("select * from Sousrubrique join rubrique on SousRubrique.IdRubrique = Rubrique.IdRubrique where NomRubrique = '" + listBox1.SelectedItem + "'", connect);
            SqlDataReader resultat = requete.ExecuteReader();
            while (resultat.Read())
            {
                listBox2.Items.Add(resultat["NomSousRubrique"].ToString());

            }
            resultat.Close();
            connect.Close();

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            SqlConnection connect = new SqlConnection("server=(local); integrated security = true; database = FilRouge_essai_modif");
            connect.Open();
            SqlCommand requete = new SqlCommand("select ImageProd from produit where NomProdCourt='"+listBox3.SelectedItem +"'", connect);
            SqlDataReader resultat = requete.ExecuteReader();
            while (resultat.Read())
            {
                FileStream fs = new FileStream(@"C:\Users\stagiaire\Dropbox\FilRouge\Avec-Modif\Image\" + resultat["ImageProd"].ToString() + "", FileMode.Open);
                pictureBox1.Image = Image.FromStream(fs);
                fs.Close();

                

            }
            resultat.Close();
            connect.Close();
        }
    }
}
