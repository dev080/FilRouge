using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRougeDAO.DAO
{
    class Commande
    {
        public int IdCommande { get; set; }
        public String EtatCommande { get; set; }
        public DateTime DateCommande { get; set; }
        public decimal MontantCommande {get; set; }
        public DateTime? DatePaiement { get; set; }
        public int IdClient { get; set; }
        public int? IdFacture { get; set; }


    }
}
