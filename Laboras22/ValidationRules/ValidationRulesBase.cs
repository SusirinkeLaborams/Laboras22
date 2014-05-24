using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Laboras22.ValidationRules
{
    abstract class ValidationRulesBase : ValidationRule
    {
        public ValidationRulesBase()
        {
            ValidatesOnTargetUpdated = true;
        }
    }
}
