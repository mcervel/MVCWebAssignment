using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MatejCervelinMvcProjekt.Models.CustomValidators
{
    public class DrzavaNazivValidator:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int nazivDrzaveMaxLength = 50;
            var drzava = validationContext.ObjectInstance as Drzava;
            if (drzava.Naziv == null) return ValidationResult.Success;
            return drzava.Naziv.Length <= nazivDrzaveMaxLength ? ValidationResult.Success : new ValidationResult($"Broj znakova za naziv države je:{drzava.Naziv.Length}, a maksimalno dozvoljeno znakova je : {nazivDrzaveMaxLength}");
        }
    }
}