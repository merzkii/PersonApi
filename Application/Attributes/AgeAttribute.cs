using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Attributes
{
    public class AgeAttribute:ValidationAttribute
    {
        private readonly int _minimumAge;

        public AgeAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || !(value is DateTime))
            {
                // If the value is null or not a DateTime, return an error.
                return new ValidationResult("A valid date is required.");
            }

            var date = (DateTime)value;
            var age = DateTime.Today.Year - date.Year;

            // Check for a leap year.
            if (date > DateTime.Today.AddYears(-age)) age--;

            if (age < _minimumAge)
            {
                return new ValidationResult($"You must be at least {_minimumAge} years old.");
            }

            return ValidationResult.Success;
        }
    }
}
