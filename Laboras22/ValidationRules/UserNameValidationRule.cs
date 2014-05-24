using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Laboras22.ValidationRules
{
    class UserNameValidationRule : ValidationRulesBase
    {
        public string FieldName { get; set; }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            var userName = (string)value;

            if (string.IsNullOrEmpty(userName))
            {
                return new ValidationResult(false, FieldName + " cannot be empty.");
            }

            if (userName.Length < 6)
            {
                return new ValidationResult(false, FieldName + " length has to be at least 6 symbols long.");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
