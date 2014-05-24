using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Laboras22.ValidationRules
{
    class NotEmptyValidationRule : ValidationRulesBase
    {
        public string FieldName { get; set; }
        
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return new ValidationResult(false, FieldName + " cannot be empty.");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
