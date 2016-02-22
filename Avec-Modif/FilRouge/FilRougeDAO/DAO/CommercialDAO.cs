using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRougeDAO.DAO
{
    class CommercialDAO
    {
        SqlConnection _connect;


        public CommercialDAO(String chaine)
        {
            _connect = new SqlConnection(chaine);

        }

        public List<Commercial> ListCommer()
        {
            _connect.Open();

            List<Commercial> resultat = new List<Commercial>();

            SqlCommand requete = new SqlCommand("select * from Commercial ", _connect);
            SqlDataReader lecture = requete.ExecuteReader();

            while (lecture.Read())
            {
                Commercial c = new Commercial();

                c.Idcommercial = Convert.ToInt32(lecture["idcommercial"]);
                c.nomcommercial = Convert.ToString(lecture["Nomcommercial"]);
                
                resultat.Add(c);
            }
            lecture.Close();
            _connect.Close();
            return resultat;
        }
    }
}
