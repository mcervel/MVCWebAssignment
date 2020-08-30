using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MatejCervelinMvcProjekt.Models.CustomValidators
{
    public class BrojRacunaValidator:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int brojRacunaMaxLength = 25;
            var racun = validationContext.ObjectInstance as Racun;
            if (racun.BrojRacuna == null) return ValidationResult.Success;
            return racun.BrojRacuna.Length <= brojRacunaMaxLength ? ValidationResult.Success : new ValidationResult($"Broj znakova za broj računa je:{racun.BrojRacuna.Length}, a maksimalno dozvoljeno znakova je : {brojRacunaMaxLength}");
        }

    }
}