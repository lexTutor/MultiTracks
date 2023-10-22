using System.ComponentModel.DataAnnotations;

namespace MTEFDataAccess.CustomAttributes
{
    public class ValidateUrlAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string imageUrl = value.ToString();

                bool isImageUrlValid = Uri.TryCreate(imageUrl, UriKind.Absolute, out Uri uriResult)
                    && (uriResult.Scheme == Uri.UriSchemeHttps);

                if (isImageUrlValid)
                    return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage ?? "Invalid HTTPS URL provided.");
        }
    }
}
