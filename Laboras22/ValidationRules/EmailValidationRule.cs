using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Laboras22.ValidationRules
{
    class EmailValidationRule : ValidationRule
    {
        bool failedValidation;

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            var email = (string)value;
            failedValidation = false;
            
            if (string.IsNullOrEmpty(email))
            {
                return new ValidationResult(false, "Specified invalid email address.");
            }
 
            try
            {
                email = Regex.Replace(email, @"(@)(.+)$", this.DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                failedValidation = true;
            }

            if (failedValidation)
            {
                return new ValidationResult(false, "Specified invalid email address.");
            }

            try
            {
                failedValidation = !Regex.IsMatch(email,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                failedValidation = true;
            }
            
            if (failedValidation)
            {
                return new ValidationResult(false, "Specified email address is not valid");
            }

            return new ValidationResult(true, null);            
        }


        private string DomainMapper(Match match)
        {
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                failedValidation = true;
            }

            return match.Groups[1].Value + domainName;
        }
    }
}
