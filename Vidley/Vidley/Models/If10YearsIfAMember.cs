using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidley.Models
{
    public class If18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == 1)
            {
                return ValidationResult.Success;
            }

            //if (customer.MembershipTypeId == null)
            //{
            //    return new ValidationResult("Choose membership type");
            //}

            if (customer.BirthDate == null)
            {
                return new ValidationResult("Birth date is required");
            }

            var customerAge = DateTime.Now.Year - customer.BirthDate.Value.Year;

            return (customerAge >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("User should be at least 18 years old");
        }
    }
}