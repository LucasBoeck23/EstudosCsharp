using System.ComponentModel.DataAnnotations;

namespace ApiCatalogo.Validations
{
    public class PrimeiraLetraMaiusculaAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value,
                    ValidationContext validationContext)
        {
            if (value is null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }
            var primeira = value.ToString()[0].ToString();
            if( primeira != primeira.ToUpper())
            {
                return new ValidationResult("A primeira letra deve ser maiúscula");
            }
            return ValidationResult.Success;
        }
    }
}
