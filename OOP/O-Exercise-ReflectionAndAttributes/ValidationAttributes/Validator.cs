using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ValidationAttributes.Attributes;

namespace ValidationAttributes;

public static class Validator
{
    public static bool IsValid(object obj)
    {
        Type type = obj.GetType();

        PropertyInfo[] properties = type.GetProperties();

        PropertyInfo[] propertiesWithCustomAttributes = properties.Where(p => Attribute.IsDefined(p, typeof(MyValidationAttribute), inherit: true)).ToArray();

        foreach (var property in propertiesWithCustomAttributes)
        {
            var validationAttributes = property.GetCustomAttributes(typeof(MyValidationAttribute), inherit: true).Cast<MyValidationAttribute>();

            foreach (var attribute in validationAttributes)
            {
                object value = property.GetValue(obj);
                if (attribute.IsValid(value) == false)
                {
                    return false;
                }
            }
        }

        //foreach (var property in properties)
        //{
        //    Console.WriteLine(property.Name);
        //}

        //Console.WriteLine();

        //foreach (var property in propertiesWithCustomAttributes)
        //{
        //    Console.WriteLine(property.Name);
        //}

        return true;
    }
}
