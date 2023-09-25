using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Utils
{
    public static class ObjectUtils
    {
        public static T CopyValues<T>(object formSource, T toTarget)
        {
            if (formSource == null)
            {
                return toTarget;
            }

            Type t = typeof(T);

            var properties = t.GetProperties().Where(prop => prop.CanRead && prop.CanWrite);

            foreach (var prop in properties)
            {
                var sourceProp = formSource.GetType().GetProperty(prop.Name);
                if (sourceProp == null)
                {
                    continue;
                }
                var value = sourceProp.GetValue(formSource, null);
                if (value != null)
                {
                    prop.SetValue(toTarget, value, null);
                }
            }

            return toTarget;
        }
    }
}
