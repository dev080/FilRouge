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
    }
}
