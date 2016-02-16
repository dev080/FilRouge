using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FilRougeDAO
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            try
            {
                SqlConnection connect = new SqlConnection("server=(local); integrated security = false;user id=" + textBox1.Text + ";password=" + textBox2.Text + "; database = master");
                connect.Open();

                MessageBox.Show("Réussi");




                connect.Close();
            }
            catch (InvalidOperationException el)
            {
                MessageBox.Show("exception 1 " + el.Message);

            }
            catch (SqlException)
            {
                // MessageBox.Show("exception 2 " + el.Message);
                //je regarde dans la base si l'utilisateur est connu.
                SqlConnection connect = new SqlConnection("server=(local); integrated security = true; database = master");
                connect.Open();

                SqlCommand requete = new SqlCommand("SELECT * FROM sys.server_principals where name = '" + textBox1.Text + "'", connect);
                SqlDataReader resultat = requete.ExecuteReader();

                if (resultat.Read())
                {
                    MessageBox.Show("utilisateur connu");

                }
                else
                {
                    MessageBox.Show("utilisateur pas connu");
                }
            }






        }
    }
}
