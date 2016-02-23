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
        //public Client select (int id)
        //{
        //    _connect.Open();

        //}
        public void update(Client g)
        {
            _connect.Open();


            
            SqlCommand requete = new SqlCommand("update client set CiviliteClient=@cv, NomClient=@nom,PrenomClient=@prenom,CategorieClient=@cat,AdrLivraisonClient=@adrl,AdrFacturationClient=@adrf,CoeffClient=@cof,Reduction=@red,IdCommercial=@idc where IdClient=@id", _connect);


            requete.Parameters.AddWithValue("@id", g.IdClient);
            requete.Parameters.AddWithValue("@cv", g.civiliteclient);
            requete.Parameters.AddWithValue("@nom", g.Nomclient);
            requete.Parameters.AddWithValue("@prenom", g.PrenomClient);
            requete.Parameters.AddWithValue("@cat", g.CategorieClient);
            requete.Parameters.AddWithValue("@adrl", g.AdrlivraisonClient);
            requete.Parameters.AddWithValue("@adrf", g.AdrFacturationClient);
            requete.Parameters.AddWithValue("@cof", g.Coeffclient);
            requete.Parameters.AddWithValue("@red", g.Reduction);
            requete.Parameters.AddWithValue("@idc", g.Idcommercial);
            requete.ExecuteNonQuery();



            _connect.Close();

        }

        public List<Client> ListCli()
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

        
        public void ajouter(Client c)
        {
            _connect.Open();

            SqlCommand requete = new SqlCommand("insert into client (Civiliteclient, nomclient,prenomclient,categorieclient,adrlivraisonclient,adrfacturationclient,coeffclient,reduction,idcommercial) values(@cv, @nom,@prenom,@cat,@adrl,@adrf,@cof,@red,@idc) ", _connect);

            

            requete.Parameters.AddWithValue("@cv", c.civiliteclient);
            requete.Parameters.AddWithValue("@nom", c.Nomclient);
            requete.Parameters.AddWithValue("@prenom",c.PrenomClient);
            requete.Parameters.AddWithValue("@cat", c.CategorieClient);
            requete.Parameters.AddWithValue("@adrl", c.AdrlivraisonClient);
            requete.Parameters.AddWithValue("@adrf", c.AdrFacturationClient);
            requete.Parameters.AddWithValue("@cof", c.Coeffclient);
            requete.Parameters.AddWithValue("@red", c.Reduction);
            requete.Parameters.AddWithValue("@idc", c.Idcommercial);
            requete.ExecuteNonQuery();



            _connect.Close();



        }
    }
}
