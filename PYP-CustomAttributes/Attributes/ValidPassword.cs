using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PYP_CustomAttributes.Attributes
{
    public class ValidPassword:ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            Match match = regex.Match(value.ToString());
            if (!match.Success)
            {
                return false;
            }
           
            return true;
        }
    }
  
}
