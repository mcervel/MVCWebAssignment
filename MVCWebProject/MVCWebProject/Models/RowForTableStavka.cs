using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatejCervelinMvcProjekt.Models
{
    public class RowForTableStavka
    {
        public int IDStavka { get; set; }
        public short Kolicina { get; set; }
        public decimal CijenaPoKomadu { get; set; }
        public decimal PopustUPostocima { get; set; }
        public decimal UkupnaCijena { get; set; }

        public string NazivProizvoda { get; set; }
        public string BrojProizvoda { get; set; }
        public decimal CijenaBezPDV { get; set; }

        public string NazivPotkategorije { get; set; }

        public string NazivKategorije { get; set; }

    }
}