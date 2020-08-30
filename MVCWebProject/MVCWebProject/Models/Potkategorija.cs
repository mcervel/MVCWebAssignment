using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatejCervelinMvcProjekt.Models
{
    public class Potkategorija
    {
        public int IDPotkategorija { get; set; }
        public int KategorijaID { get; set; }
        public string Naziv { get; set; }
        public Potkategorija()
        {

        }
    }
}