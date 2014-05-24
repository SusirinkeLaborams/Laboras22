using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Laboras22.ValidationRules
{
    class PasswordValidationRule : ValidationRulesBase
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            var name = (string)value;

            if (name.Length < 8)
            {
                return new ValidationResult(false, "Password must at least 8 characters long.");
            }

            if (!name.Any(x => char.IsLetter(x)) || !name.Any(x => !char.IsLetter(x)))
            {
                return new ValidationResult(false, "Password has to contain at least one letter and one other character.");
            }

            return new ValidationResult(true, null);
        }
    }
}
