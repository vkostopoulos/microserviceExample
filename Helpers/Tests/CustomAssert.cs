using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Helpers.Tests
{
    public static class CustomAssert<T> where T : class
    {
        public static bool Compare(object x, object y)
        {
            T lhs = x as T;
            T rhs = y as T;
            if (lhs == null || rhs == null) throw new InvalidOperationException();
            return Compare(lhs, rhs);
        }

        public static bool Compare(IEnumerable<T> x, IEnumerable<T> y)
        {
            if (x.Count() != y.Count())
            {
                return false;
            }

            for (int i =0; i < x.Count(); i++)
            {
                if (Compare(x.ElementAt(i), y.ElementAt(i)))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool Compare(T x, T y)
        {
            Type type = typeof(T);
            foreach (PropertyInfo pi in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                object selfValue = type.GetProperty(pi.Name).GetValue(x, null);
                object toValue = type.GetProperty(pi.Name).GetValue(y, null);

                if (selfValue != toValue && (selfValue == null || !selfValue.Equals(toValue)))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
