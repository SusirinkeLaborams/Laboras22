using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Laboras22.ValidationRules
{
    class ConfirmPasswordValidationRule : ValidationRulesBase
    {
        private PasswordBox m_OriginalPasswordBox;

        public ConfirmPasswordValidationRule(PasswordBox originalPasswordBox)
        {
            m_OriginalPasswordBox = originalPasswordBox;
        }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            var password = (string)value;

            if (password != m_OriginalPasswordBox.Password)
            {
                return new ValidationResult(false, "Passwords must match.");
            }

            return new ValidationResult(true, null);
        }
    }
}
