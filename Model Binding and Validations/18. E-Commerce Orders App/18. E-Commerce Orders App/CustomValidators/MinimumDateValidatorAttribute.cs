using System.ComponentModel.DataAnnotations;

namespace _18._E_Commerce_Orders_App.CustomValidators
{
    public class MinimumDateValidatorAttribute : ValidationAttribute
    {
        public string DefaultErrorMessage { get; set; } = "Order date should be greater than or equal to {0}";
        public DateTime MinimumDate { get; set; }

        public MinimumDateValidatorAttribute(string minimumDateString)
        {
            MinimumDate = Convert.ToDateTime(minimumDateString);
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime orderDate = (DateTime)value;

                if (orderDate < MinimumDate)
                {
                    return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, MinimumDate.ToString("yyyy-MM-dd")), new string[] { nameof(validationContext.MemberName) });
                }

                return ValidationResult.Success;
            }
            return null;
        }
    }
}
