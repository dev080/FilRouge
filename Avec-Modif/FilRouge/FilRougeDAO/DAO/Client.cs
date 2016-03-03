using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRougeDAO.DAO
{
    public class Client
    {

        public int IdClient { get; set; }
        public String civiliteclient { get; set; }
        public String Nomclient { get; set; }
        public String PrenomClient { get; set; }
        public String CategorieClient { get; set; }
        public String AdrlivraisonClient { get; set; }
        public String AdrFacturationClient { get; set; }
        public int Coeffclient { get; set; }
        public int Reduction { get; set; }
        public int Idcommercial { get; set; }

    }
}
