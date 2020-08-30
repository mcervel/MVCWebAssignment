using MatejCervelinMvcProjekt.Models.CustomValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MatejCervelinMvcProjekt.Models
{
    public class Racun
    {
        public int IDRacun { get; set; }
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Datum izdavanja je obavezan")]
        public DateTime DatumIzdavanja { get; set; }
        [Required(ErrorMessage = "Broj računa je obavezan")]
        [BrojRacunaValidator]
        public string BrojRacuna { get; set; }
        [Required(ErrorMessage = "KupacID je obavezan")]
        public int KupacID { get; set; }
        public int KomercijalistID { get; set; }
        public int KreditnaKarticaID { get; set; }
        [KomentarValidator]
        public string Komentar { get; set; }
        public Racun()
        {

        }
    }
}