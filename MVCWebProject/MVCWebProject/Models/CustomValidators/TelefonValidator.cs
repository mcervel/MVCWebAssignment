using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MatejCervelinMvcProjekt.Models.CustomValidators
{
    public class TelefonValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int telefonMaxLength = 25;
            var kupac = validationContext.ObjectInstance as Kupac;
            if (kupac.Telefon == null) return ValidationResult.Success;
            return kupac.Telefon.Length <= telefonMaxLength ? ValidationResult.Success : new ValidationResult($"Broj znakova za telefon je:{kupac.Telefon.Length}, a maksimalno dozvoljeno znakova je : {telefonMaxLength}");
        }
    }
}