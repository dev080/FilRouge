using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRougeDAO.DAO
{
    


    class ClientDAO
    {


SqlConnection _connect;


        public ClientDAO(String chaine)
        {
            _connect = new SqlConnection(chaine);

        }

        public List<Client> ListCommer()
        {
            _connect.Open();

            List<Client> resultat = new List<Client>();

            SqlCommand requete = new SqlCommand("select * from Client ", _connect);
            SqlDataReader lecture = requete.ExecuteReader();

            while (lecture.Read())
            {
                Client c = new Client();

                c.IdClient = Convert.ToInt32(lecture["idclient"]);
                c.civiliteclient = Convert.ToString(lecture["civiliteclient"]);
                c.Nomclient = Convert.ToString(lecture["NomClient"]);
                c.PrenomClient = Convert.ToString(lecture["PrenomClient"]);
                c.CategorieClient = Convert.ToString(lecture["CategorieClient"]);
                c.AdrlivraisonClient = Convert.ToString(lecture["Adrlivraisonclient"]);
                c.AdrFacturationClient = Convert.ToString(lecture["AdrFacturationclient"]);
                c.Coeffclient = Convert.ToInt32(lecture["coeffclient"]);
                c.Reduction = Convert.ToInt32(lecture["reduction"]);
                c.Idcommercial = Convert.ToInt32(lecture["Idcommercial"]);


                resultat.Add(c);
            }
            lecture.Close();
            _connect.Close();
            return resultat;
        }
    }
}
