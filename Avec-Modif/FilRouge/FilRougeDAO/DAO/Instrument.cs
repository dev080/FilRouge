using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRougeDAO.DAO
{
    class Instrument
    {
        public int IdProduit { get; set; }
        public String NomProdCourt { get; set; }
        public String NomProdLong { get; set; }
        public String Imageprod { get; set; }
        public Decimal PrixHT_Prod { get; set; }
        public bool ActifProduit { get; set; }
        public int StockProduit { get; set; }
        public int IdSousRubrique { get; set; }
    }
}
