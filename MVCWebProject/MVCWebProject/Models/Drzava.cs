using MatejCervelinMvcProjekt.Models.CustomValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MatejCervelinMvcProjekt.Models
{
    public class Drzava
    {
        public int IDDrzava { get; set; }
        [Required(ErrorMessage = "Naziv države je obavezan")]
        [DrzavaNazivValidator]
        public string Naziv { get; set; }
        public Drzava()
        {

        }
    }
}