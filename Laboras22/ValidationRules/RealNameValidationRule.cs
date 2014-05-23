using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Laboras22.ValidationRules
{
    class RealNameValidationRule : ValidationRule
    {
        public string FieldName { get; set; }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            var name = (string)value;
            
            if (string.IsNullOrEmpty(name))
            {
                return new ValidationResult(false, FieldName + " cannot be empty");
            }

            if (name.Any(x => !char.IsLetter(x) && x != ' ' && x != '\''))
            {
                return new ValidationResult(false, FieldName + " may only contain letters, spaces and apostrophes");
            }

            return new ValidationResult(true, null);
        }
    }
}
