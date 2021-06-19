using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AJC.Logistics.SeaWideExpress.QuotingTool.Helpers
{
    public static class TypesHelper
    {
        public static object ChangeType(object value, Type conversion)
        {
            var t = conversion;

            if (t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null)
                {
                    return null;
                }

                t = Nullable.GetUnderlyingType(t);
            }

            return Convert.ChangeType(value, t);
        }
    }
}
