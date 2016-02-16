using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRougeDAO.DAO
{
    class SsRubriqueDAO
    {
        SqlConnection _connect;

        public SsRubriqueDAO(string chaine)
        {
            _connect = new SqlConnection(chaine);

        }

        public List<SsRubrique> List(Rubrique g)
        {
            _connect.Open();

            List<SsRubrique> resultat = new List<SsRubrique>();

            SqlCommand requete = new SqlCommand("select * from SousRubrique where IdRubrique='"+g.Idrubrique+"'", _connect);
            SqlDataReader lecture = requete.ExecuteReader();

            while (lecture.Read())
            {
                SsRubrique c = new SsRubrique();
                c.IdSousRubrique = Convert.ToInt32(lecture["idSousrubrique"]);
                c.NomSousrubrique = Convert.ToString(lecture["nomsousrubrique"]);

                resultat.Add(c);
            }
            lecture.Close();
            _connect.Close();
            return resultat;
        }
    }
}
