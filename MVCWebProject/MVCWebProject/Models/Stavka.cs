using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MatejCervelinMvcProjekt.Models
{
    public class Stavka
    {
        public int IDStavka { get; set; }
        [Required(ErrorMessage = "RacunID je obavezan")]
        public int RacunID { get; set; }
        [Required(ErrorMessage = "Kolicina je obavezna")]
        public short Kolicina { get; set; }
        [Required(ErrorMessage = "ProizvodID je obavezan")]
        public int ProizvodID { get; set; }
        [Required(ErrorMessage = "Cijena po komadu je obavezna")]
        public decimal CijenaPoKomadu { get; set; }
        [Required(ErrorMessage = "Popust u postocima je obavezan")]
        public decimal PopustUPostocima { get; set; }
        [Required(ErrorMessage = "Ukupna cijena je obavezna")]
        public decimal UkupnaCijena { get; set; }
        public Stavka()
        {

        }
    }
}