using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using TasleemDelivery.Data;

namespace TasleemDelivery.SharedValidation.CustomValidations
{

    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Check if the value is null or empty (not required)
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            // Perform the uniqueness check here
            var dbContext = (Context)validationContext.GetService(typeof(Context));
            var existingUser = dbContext.Users.FirstOrDefault(u => u.Email == value.ToString());

            if (existingUser != null)
            {
                return new ValidationResult("The email address is already in use.");
            }

            return ValidationResult.Success;
        }
    }

}










