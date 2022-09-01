



using PYP_CustomAttributes.Attributes.AttributeValidators;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PYP_CustomAttributes.Attributes
{
    public class ValidPassword:ValidationAttribute
    {
        private bool _isValidPassword;
        public override bool IsValid(object? value)
        {
            Regex regex = new Regex(@"^(.{0,7}|[^0-9]*|[^A-Z])$");
            Match match = regex.Match(value.ToString());
            if (!match.Success)
            {
                _isValidPassword = false;
            }
            _isValidPassword = true;
            return match.Success;
        }
    }
  
}
