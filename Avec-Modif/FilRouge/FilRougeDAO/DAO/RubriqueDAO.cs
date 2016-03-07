using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRougeDAO.DAO
{
    class RubriqueDAO
    {
        SqlConnection _connect;

        public RubriqueDAO(string chaine)
        {
            _connect = new SqlConnection(chaine);

        }

        public List<Rubrique> List()
        {
            _connect.Open();
            List<Rubrique> resultat = new List<Rubrique>();
            SqlCommand requete = new SqlCommand("select * from Rubrique", _connect);
            SqlDataReader lecture = requete.ExecuteReader();

            while (lecture.Read())
            {
                Rubrique c = new Rubrique();
                 c.Idrubrique = Convert.ToInt32(lecture["idrubrique"]);
                c.NomRubrique = Convert.ToString(lecture["nomrubrique"]);
                
                resultat.Add(c);
            }
            lecture.Close();
            _connect.Close();
            return resultat;
        }


        public void update (int indice,string table)
        {
            _connect.Open();

            SqlCommand requete2 = new SqlCommand("update Rubrique set NomRubrique=@table where IdRubrique=@indice", _connect);
            requete2.Parameters.AddWithValue("@indice", indice);
            requete2.Parameters.AddWithValue("@table", table);

            requete2.ExecuteNonQuery();

            _connect.Close();

            

        }


    }
}
