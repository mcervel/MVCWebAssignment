using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MatejCervelinMvcProjekt.Models.CustomValidators
{
    public class KomentarValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int komentarMaxLength = 128;
            var racun = validationContext.ObjectInstance as Racun;
            if (racun.Komentar == null) return ValidationResult.Success;
            return racun.Komentar.Length <= komentarMaxLength ? ValidationResult.Success : new ValidationResult($"Broj znakova za komentar je:{racun.Komentar.Length}, a maksimalno dozvoljeno znakova je : {komentarMaxLength}");
        }
    }
}