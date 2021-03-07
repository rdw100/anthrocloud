using System;
using System.ComponentModel.DataAnnotations;

namespace AnthroCloud.Entities
{
    internal class CheckFutureDateRange : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dt = (DateTime)value;
            if (dt >= DateTime.Now.Date)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage ?? "Make sure your date is >= than today.");
        }
    }
}