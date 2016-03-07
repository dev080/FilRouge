using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRougeDAO.DAO
{
    
    class InstrumentDAO
    {
        SqlConnection _connect;

        
        public InstrumentDAO(String chaine)
        {
            _connect = new SqlConnection(chaine);

        }

        public List<Instrument> List(SsRubrique g)
        {
            _connect.Open();

            List<Instrument> resultat = new List<Instrument>();

            SqlCommand requete = new SqlCommand("select * from Produit where IdSousRubrique='" + g.IdSousRubrique + "'", _connect);
            SqlDataReader lecture = requete.ExecuteReader();

            while (lecture.Read())
            {
                Instrument c = new Instrument();

                c.IdProduit = Convert.ToInt32(lecture["idproduit"]);
                c.NomProdCourt = Convert.ToString(lecture["NomProdCourt"]);
                c.NomProdLong = Convert.ToString(lecture["NomProdLong"]);
                c.Imageprod = Convert.ToString(lecture["Imageprod"]);
                c.PrixHT_Prod = Convert.ToDecimal(lecture["PrixHT_Prod"]);
                c.ActifProduit = Convert.ToBoolean(lecture["ActifProduit"]);
                c.StockProduit = Convert.ToInt32(lecture["StockProduit"]);
                c.IdSousRubrique = Convert.ToInt32(lecture["IdSousRubrique"]);

                resultat.Add(c);
            }
            lecture.Close();
            _connect.Close();
            return resultat;
        }


        public void update(int indice, string table)
        {
            _connect.Open();

            SqlCommand requete2 = new SqlCommand("update Produit set NomProdCourt=@table where IdProduit=@indice", _connect);
            requete2.Parameters.AddWithValue("@indice", indice);
            requete2.Parameters.AddWithValue("@table", table);

            requete2.ExecuteNonQuery();

            _connect.Close();



        }

    }
}
