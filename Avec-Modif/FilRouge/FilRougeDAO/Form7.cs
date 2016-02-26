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
            //TreeNode tNode;

            //tNode = treeView1.Nodes.Add("Websites1");
            //tNode = treeView1.Nodes.Add("Websites2");
            //tNode = treeView1.Nodes.Add("Websites3");
            //tNode = treeView1.Nodes.Add("Websites4");
            //tNode = treeView1.Nodes.Add("Websites5");

            //treeView1.Nodes[0].Nodes.Add("Net-informations.com");
            //treeView1.Nodes[0].Nodes[0].Nodes.Add("CLR");

            //treeView1.Nodes[0].Nodes.Add("Vb.net-informations.com");
            //treeView1.Nodes[0].Nodes[1].Nodes.Add("String Tutorial");
            //treeView1.Nodes[0].Nodes[1].Nodes.Add("Excel Tutorial");

            //treeView1.Nodes[0].Nodes.Add("Csharp.net-informations.com");
            //treeView1.Nodes[0].Nodes[2].Nodes.Add("ADO.NET");
            //treeView1.Nodes[0].Nodes[2].Nodes[0].Nodes.Add("Dataset");






            SqlConnection _connect = new SqlConnection("Server=.;Database=FilRouge_essai_modif;Integrated security=true");
            _connect.Open();

            SqlCommand sql = new SqlCommand("Select * from Rubrique", _connect);
            SqlDataReader resultat = sql.ExecuteReader();

            while (resultat.Read())
            {
                //treeView2.Nodes[resultat["Idrubrique"].ToString()].Nodes.Add(resultat["Nomrubrique"].ToString());
                TreeNode tNode = new TreeNode(resultat["NomRubrique"].ToString());

                int d = (int)resultat["IdRubrique"];

                SqlConnection _connect2 = new SqlConnection("Server=.;Database=FilRouge_essai_modif;Integrated security=true");
                _connect2.Open();

                SqlCommand sql2 = new SqlCommand("Select * from SousRubrique where Idrubrique=@var", _connect2);
                sql2.Parameters.AddWithValue("@var", d);
                SqlDataReader resultat2 = sql2.ExecuteReader();

                int i = 0;
                while (resultat2.Read())
                {
                    TreeNode tNode2 = new TreeNode(resultat2["NomSousRubrique"].ToString());

                    Console.WriteLine("Affichage de IdRubrique " + (d - 1));
                    

                    int d2 = (int)resultat2["IdSousRubrique"];

                    SqlConnection _connect3 = new SqlConnection("Server=.;Database=FilRouge_essai_modif;Integrated security=true");
                    _connect3.Open();

                    SqlCommand sql3 = new SqlCommand("Select * from Produit where IdSousrubrique=@var2", _connect3);
                    sql3.Parameters.AddWithValue("@var2", d2);
                    SqlDataReader resultat3 = sql3.ExecuteReader();

                    //Console.WriteLine("Reiniti");
                    while (resultat3.Read())
                    {
                        TreeNode tNode3 = new TreeNode(resultat3["NomProdCourt"].ToString());
                        Console.WriteLine("Affichage de IdSousRubrique " + (i));

                        //treeView2.Nodes[d - 1].Nodes[i].Nodes.Add(resultat3["NomProdCourt"].ToString());
                        i++;

                        tNode2.Nodes.Add(tNode3);
                    }
                    tNode.Nodes.Add(tNode2);

                }
                treeView2.Nodes.Add(tNode);
            }

            // EXEMPLE treeView2.Nodes[IdRubrique].Nodes[IdSousRubrique].Nodes[Idproduit].Nodes.Add("Dataset");

        }
    }
}
