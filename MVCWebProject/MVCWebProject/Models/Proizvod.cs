using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatejCervelinMvcProjekt.Models
{
    public class Proizvod
    {
        public int IDProizvod { get; set; }
        public string Naziv { get; set; }
        public string BrojProizvoda { get; set; }
        public string Boja { get; set; }
        public short MinimalnaKolicinaNaSkladistu { get; set; }
        public decimal CijenaBezPDV { get; set; }
        public int PotkategorijaID { get; set; }
        public Proizvod()
        {

        }
    }
}