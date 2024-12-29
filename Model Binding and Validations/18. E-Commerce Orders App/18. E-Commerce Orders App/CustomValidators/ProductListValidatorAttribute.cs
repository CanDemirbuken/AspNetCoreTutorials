using _18._E_Commerce_Orders_App.Models;
using System.ComponentModel.DataAnnotations;

namespace _18._E_Commerce_Orders_App.CustomValidators
{
    public class ProductsListValidatorAttribute : ValidationAttribute
    {
        public string DefaultErrorMessage { get; set; } = "Order should have at least one product";

        public ProductsListValidatorAttribute()
        {
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                List<Product> products = (List<Product>)value;

                if (products.Count == 0)
                {
                    return new ValidationResult(DefaultErrorMessage, new string[] { nameof(validationContext.MemberName) });
                }

                return ValidationResult.Success;
            }
            return null;
        }
    }
}
