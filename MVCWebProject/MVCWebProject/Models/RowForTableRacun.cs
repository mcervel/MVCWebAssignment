using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatejCervelinMvcProjekt.Models
{
    public class RowForTableRacun
    {
        public int IDRacun { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public string BrojRacuna { get; set; }

        public string Ime { get; set; }
        public string Prezime { get; set; }

        public string Tip { get; set; }
        public string Broj { get; set; }

        public RowForTableRacun()
        {

        }
    }
}