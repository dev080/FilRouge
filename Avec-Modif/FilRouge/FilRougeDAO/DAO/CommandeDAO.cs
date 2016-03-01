using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRougeDAO.DAO
{
    class CommandeDAO
    {
        SqlConnection _connect;

        public CommandeDAO(String Chaine)
        {
            _connect = new SqlConnection(Chaine);

        }


        public List<Commande> List_Com(Client cli)
        {
            List<Commande> list = new List<Commande>();
            _connect.Open();

            SqlCommand str = new SqlCommand("Select * from Commande where Idclient=@var", _connect);
            str.Parameters.AddWithValue("@var", cli.IdClient);

            SqlDataReader lecture = str.ExecuteReader();

            while (lecture.Read())
            {
                Commande c = new Commande();

                c.IdCommande = Convert.ToInt32(lecture["idcommande"]);

                c.EtatCommande = Convert.ToString(lecture["EtatCommande"]);

                c.DateCommande = Convert.ToDateTime(lecture["DateCommande"]);

                c.MontantCommande = Convert.ToDecimal(lecture["MontantCommande"]);

                if (lecture["DatePaiement"] == DBNull.Value)
                {
                    c.DatePaiement = null;
                }
                else
                {
                    c.DatePaiement = Convert.ToDateTime(lecture["DatePaiement"]);

                }


                c.IdClient = Convert.ToInt32(lecture["IdClient"]);


                if (lecture["IdFacture"] == DBNull.Value)
                {
                    c.IdFacture = null;
                }
                else
                {
                    c.IdFacture = Convert.ToInt32(lecture["IdFacture"]);

                }

                //c.IdFacture = Convert.ToInt32(lecture["IdFacture"]);


                list.Add(c);
            }
            lecture.Close();

           
            _connect.Close();
            return list;
        }



    }
}
