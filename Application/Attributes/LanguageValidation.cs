using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Attributes
{
    public class LanguageValidation:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || !(value is string stringValue))
            {
                // If the value is null or not a string, we consider it not valid.
                return new ValidationResult("Value is required.");
            }

            // Regular expression for English characters only
            var englishRegex = new Regex("^[A-Za-z]+$");
            // Regular expression for Georgian characters only
            var georgianRegex = new Regex("^[\u10A0-\u10FF]+$");

            bool isEnglish = englishRegex.IsMatch(stringValue);
            bool isGeorgian = georgianRegex.IsMatch(stringValue);

            if (isEnglish || isGeorgian)
            {
                return ValidationResult.Success;
            }
            else
            {
                // If the string does not match either regex, return a validation error
                return new ValidationResult("The value must consist of all English or all Georgian characters.");
            }
        }
    }
}
