using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilRougeDAO
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            TreeNode tNode;

            tNode = treeView1.Nodes.Add("Websites1");
            tNode = treeView1.Nodes.Add("Websites2");
            tNode = treeView1.Nodes.Add("Websites3");
            tNode = treeView1.Nodes.Add("Websites4");
            tNode = treeView1.Nodes.Add("Websites5");

            treeView1.Nodes[0].Nodes.Add("Net-informations.com");
            treeView1.Nodes[0].Nodes[0].Nodes.Add("CLR");

            treeView1.Nodes[0].Nodes.Add("Vb.net-informations.com");
            treeView1.Nodes[0].Nodes[1].Nodes.Add("String Tutorial");
            treeView1.Nodes[0].Nodes[1].Nodes.Add("Excel Tutorial");

            treeView1.Nodes[0].Nodes.Add("Csharp.net-informations.com");
            treeView1.Nodes[0].Nodes[2].Nodes.Add("ADO.NET");
            treeView1.Nodes[0].Nodes[2].Nodes[0].Nodes.Add("Dataset");



            SqlConnection _connect;

            _connect = new SqlConnection("Server=.;Database=FilRouge_essai_modif;Integrated security=true");

            _connect.Open();

            SqlCommand sql = new SqlCommand("Select * from Rubrique", _connect);

            SqlDataReader resultat = sql.ExecuteReader();

            TreeNode tNode2;

            //tNode2 = treeView2.Nodes.Add("Produit");



            while (resultat.Read())
            {
                //treeView2.Nodes[resultat["Idrubrique"].ToString()].Nodes.Add(resultat["Nomrubrique"].ToString());
                tNode = treeView2.Nodes.Add(resultat["NomRubrique"].ToString());

                int d = (int)resultat["IdRubrique"];

                SqlConnection _connect2;

                _connect2 = new SqlConnection("Server=.;Database=FilRouge_essai_modif;Integrated security=true");

                _connect2.Open();

                SqlCommand sql2 = new SqlCommand("Select * from SousRubrique where Idrubrique=@var", _connect2);

                sql2.Parameters.AddWithValue("@var", d);

                SqlDataReader resultat2 = sql2.ExecuteReader();

                while (resultat2.Read())
                {
                    Console.WriteLine(d-1);
                    treeView2.Nodes[d-1].Nodes.Add(resultat2["NomSousRubrique"].ToString());


                }



            }










            //treeView2.Nodes[0].Nodes.Add("Sous-rubrique1");
            //treeView2.Nodes[0].Nodes.Add("Sous-rubrique2");
            //treeView2.Nodes[0].Nodes.Add("Sous-rubrique3");


            //treeView2.Nodes[0].Nodes[0].Nodes.Add("Instrument1");
            //treeView2.Nodes[0].Nodes[1].Nodes.Add("Instrument2");
            //treeView2.Nodes[0].Nodes[1].Nodes.Add("Instrument3");
            //treeView2.Nodes[0].Nodes[2].Nodes.Add("Instrument4");


            // treeView2.Nodes[0].Nodes[2].Nodes[0].Nodes.Add("Dataset");
        }
    }
}
