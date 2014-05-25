using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Laboras22.ValidationRules
{
    class IntValidationRule : ValidationRulesBase
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public string FieldName { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int intValue;

            try
            {
                intValue = int.Parse((string)value, cultureInfo);
            }
            catch (Exception)
            {
                return new ValidationResult(false, "Entered value is not a valid integer.");
            }

            if (intValue >= Min && intValue <= Max)
            {
                return new ValidationResult(true, null);
            }
            else
            {
                return new ValidationResult(false, FieldName + " has to be in bounds [" + Min + "; " + Max + "].");
            }
        }
    }
}
