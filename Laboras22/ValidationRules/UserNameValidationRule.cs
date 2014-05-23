using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Laboras22.ValidationRules
{
    class UserNameValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            var userName = (string)value;

            if (userName.Length > 5)
            {
                return new ValidationResult(true, null);
            }
            else
            {
                return new ValidationResult(false, "User name length has to be at least 6 symbols long.");
            }
        }
    }
}
