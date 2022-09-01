using PYP_CustomAttributes.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYP_CustomAttributes.Models
{
    public class User
    {
        public string Name { get; set; }
        [ValidEmail]
        public string Email { get; set; }
        [ValidPassword]
        public string Password { get; set; }
    }
}
