using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MatejCervelinMvcProjekt.Models.CustomValidators
{
    public class GradNazivValidator:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int nazivGradaMaxLength = 50;
            var grad = validationContext.ObjectInstance as Grad;
            if (grad.Naziv == null) return ValidationResult.Success;
            return grad.Naziv.Length <= nazivGradaMaxLength ? ValidationResult.Success : new ValidationResult($"Broj znakova za naziv grada je:{grad.Naziv.Length}, a maksimalno dozvoljeno znakova je : {nazivGradaMaxLength}");
        }
    }
}