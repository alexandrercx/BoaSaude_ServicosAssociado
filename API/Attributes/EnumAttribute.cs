using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Attributes
{
    public class EnumAttribute : ValidationAttribute
    {
        private Type EnumType { get; set; }

        public EnumAttribute(Type enumType)
        {
            EnumType = enumType;
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
                var myEnumIntValues = from long n in Enum.GetValues(EnumType).Cast<long>() select (long)n;
                var myEnumStringValues = from string n in Enum.GetValues(EnumType).Cast<string>() select (string)n;
                var myEnumStringNames = from string n in Enum.GetNames(EnumType).Cast<string>() select (string)n;

                if (value != null && (myEnumIntValues.Count() > 0 || myEnumStringValues.Count() > 0 || myEnumStringNames.Count() > 0))
                {
                    long valueInt;
                    if (long.TryParse(value.ToString(), out valueInt))
                    {
                        if (myEnumIntValues?.Count() > 0 && myEnumIntValues.Where(b => b == valueInt)?.Count() == 1)
                            return true;
                    }
                    else
                    {
                        if (myEnumStringNames?.Count() > 0 && myEnumStringNames.Where(b => b == value.ToString())?.Count() == 1)
                            return true;

                        if (myEnumStringValues?.Count() > 0 && myEnumStringValues.Where(b => b == value.ToString())?.Count() == 1)
                            return true;
                    }

                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
