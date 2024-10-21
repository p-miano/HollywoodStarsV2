using System;
using System.ComponentModel.DataAnnotations;

namespace HollywoodStars.Models.Validation;

public class CurrentYearAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value != null)
        {
            int releaseYear;
            bool isNumeric = int.TryParse(value.ToString(), out releaseYear);

            if (!isNumeric)
            {
                return new ValidationResult("Release year must be a number.");
            }

            if (releaseYear < DateTime.Now.Year)
            {
                return new ValidationResult($"Release year cannot be less than {DateTime.Now.Year}.");
            }

            return ValidationResult.Success;
        }

        return new ValidationResult("Release year is required.");
    }
}
