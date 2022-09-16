using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PYP_CustomAttributes.Attributes
{
    public class ValidEmail:ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(value.ToString());
            if (!match.Success)
            {
                return false;
            }

            return true;
        }
        

    }
}
