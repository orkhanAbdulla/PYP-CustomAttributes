using PYP_CustomAttributes.Attributes;
using PYP_CustomAttributes.Models;
using System.Reflection;


User user = new User()
{
    Name = "Orkhan",
    Email = "Orkhangmail.com",
    Password = "O"
};

PropertyInfo[] props = typeof(User).GetProperties();
foreach (var prop in props)
{
    object[] attrs = prop.GetCustomAttributes(true);
    foreach (var attr in attrs)
    {
        ValidEmail authAttr = attr as ValidEmail;
        if (authAttr != null)
        {
            var method = authAttr.GetType().GetMethod("IsValid", BindingFlags.Public | BindingFlags.Instance);
            var result = (bool)method.Invoke(attr, new object[] { prop.GetValue(user) });
            if (!result)
            {
                Console.WriteLine("Invalid Email");
            }
        }
        ValidPassword ValidPassword = attr as ValidPassword;
        if (ValidPassword!=null)
        {
            var method = ValidPassword.GetType().GetMethod("IsValid", BindingFlags.Public | BindingFlags.Instance);
            var result = (bool)method.Invoke(attr, new object[] { prop.GetValue(user) });
            if (!result)
            {
                Console.WriteLine("Invalid Password");
            }
        }
    }
}


