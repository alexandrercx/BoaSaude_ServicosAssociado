using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Attributes
{
    public class AuthorizationAttribute: ValidationAttribute
    {
        private readonly IConfiguration _Configuration;
        public AuthorizationAttribute(IConfiguration Configuration)
        {
            _Configuration = Configuration;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!IsValid(value))
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));

            return ValidationResult.Success;
        }

        public override bool IsValid(object value)
        {
            try
            {
                string apiKey = _Configuration.GetSection("ApiSettings:ApiKey").Value;

                if (value == null || string.IsNullOrWhiteSpace(value.ToString()) || string.IsNullOrWhiteSpace(apiKey))
                    return false;

                return value.Equals(apiKey);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
