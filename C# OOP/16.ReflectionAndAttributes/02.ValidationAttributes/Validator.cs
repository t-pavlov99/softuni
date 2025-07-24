using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes
{
    internal static class Validator
    {
        public static bool IsValid(object obj)
        {
            var properties = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var property in properties)
            {
                var cA = property.GetCustomAttribute(typeof(MyValidationAttribute)) as MyValidationAttribute;
                if (!cA.IsValid(property.GetValue(obj)))
                    return false;
            }

            return true;
        }
    }
}
