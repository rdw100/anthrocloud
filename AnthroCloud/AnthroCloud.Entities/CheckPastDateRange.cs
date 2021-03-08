using System;
using System.ComponentModel.DataAnnotations;

namespace AnthroCloud.Entities
{
    internal class CheckPresentDateRange : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dt = (DateTime)value;
            if (dt > DateTime.Now.Date.AddYears(-50))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage ?? "Make sure your date is within the past 50 years.");
        }
    }
}
