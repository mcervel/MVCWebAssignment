using MatejCervelinMvcProjekt.Models.CustomValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MatejCervelinMvcProjekt.Models
{
    public class Grad
    {
        public int IDGrad { get; set; }
        [Required(ErrorMessage = "Naziv grada je obavezan")]
        [GradNazivValidator]
        public string Naziv { get; set; }
        public int DrzavaID { get; set; }

        public Grad()
        {

        }

    }
}