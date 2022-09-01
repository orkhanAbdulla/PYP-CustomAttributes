using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PYP_CustomAttributes.Attributes.AttributeValidators
{
    public class ValidationService<T> where T : class
    {
        private  List<string> _errors=new List<string>();
        public  List<string> isValid(T entity, Type type)
        {
            List<PropertyInfo> propertyInfos = entity.GetType().GetRuntimeProperties().Where(x => Attribute.IsDefined(x, type)).ToList();
            foreach (var propertyInfo in propertyInfos)
            {
                string value = propertyInfo.GetValue(entity).ToString();
                if (!string.IsNullOrEmpty(value))
                if (type == typeof(ValidPassword))
                {
                    if (value.Length < 8)
                        _errors.Add("password lenght must be more 8");
                    int IsUpper = 0;
                    int IsDiggit = 0;
                    for (int i = 0; i < value.Length; i++)
                    {
                        if (Char.IsUpper(value[i]))
                        {
                            IsUpper++;
                            continue;
                        }
                        if (Char.IsDigit(value[i]))
                        {
                            IsDiggit++;
                            continue;
                        }
                    }
                    if (IsUpper == 0)
                    {
                        _errors.Add("password must be UpperCase");
                    }
                    if (IsDiggit == 0)
                    {
                        _errors.Add("password must be Digit");
                    }
                }
                else if (type == typeof(ValidEmail))
                {
                    Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    Match match = regex.Match(value);
                    if (!match.Success)
                    {
                        _errors.Add("Email format InCorrect");
                    }
                }
            }
           
            return _errors;
        }
    }
}
