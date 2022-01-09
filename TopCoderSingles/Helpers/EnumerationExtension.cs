using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace TopCoderSingles.Helpers
{
    public class EnumerationExtension
    {
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            if (fi.GetCustomAttributes(typeof(DescriptionAttribute), false) is DescriptionAttribute[] attributes && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }

        public static IEnumerable<string> GetEnumDescriptions(Type type)
        {
            var descs = new List<string>();
            var names = Enum.GetNames(type);

            foreach (var name in names)
            {
                var field = type.GetField(name);
                var fds = field.GetCustomAttributes(typeof(DescriptionAttribute), true);
                foreach (DescriptionAttribute fd in fds)
                {
                    descs.Add(fd.Description);
                }
            }
            return descs;
        }
    }
}
