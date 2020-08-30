using MatejCervelinMvcProjekt.Models.CustomValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MatejCervelinMvcProjekt.Models
{
    public class Kupac
    {
        public int IDKupac { get; set; }
        [Required(ErrorMessage = "Ime je obavezno")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Prezime je obavezno")]
        public string Prezime { get; set; }

        [EmailAddress(ErrorMessage = "Email adresa je krivo upisana!")]
        public string Email { get; set; }
        [TelefonValidator]
        public string Telefon { get; set; }

        [Display(Name = "Grad: ")]
        public int GradID { get; set; }

        public string PunoIme { get { return Ime + " " + Prezime; } }

        public override string ToString()
        {
            return $"{Ime} {Prezime}";
        }


        public Kupac()
        {
            
        }
    }
}