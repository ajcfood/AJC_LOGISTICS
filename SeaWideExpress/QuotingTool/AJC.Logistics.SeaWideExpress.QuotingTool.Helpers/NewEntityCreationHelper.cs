using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AJC.Logistics.SeaWideExpress.QuotingTool.Helpers
{
    public static class NewEntityCreationHelper
    {
        public static bool CheckMandatoryFields(object theEntity, Type theType)
        {
            IEnumerable<PropertyInfo> properties = from p in theType.GetProperties()
                                                   where (from a in p.GetCustomAttributes(false)
                                                          where a is EdmScalarPropertyAttribute
                                                          select true).FirstOrDefault()
                                                   select p;
            foreach (var property in properties)
            {
                var t = property.PropertyType;
                var l = property.GetCustomAttributes(false).Where( a => a is EdmScalarPropertyAttribute).ToList();
                    
                if (!t.IsGenericType && 
                    !property.PropertyType.AssemblyQualifiedName.ToLowerInvariant().Contains("nullable") && 
                    !property.PropertyType.AssemblyQualifiedName.ToLowerInvariant().Contains("string"))
                {
                    var nombre = property.Name;
                    var theValue = property.GetValue(theEntity, null);
                    // A mandatory int when is null, the obtained value is zero.
                    if (theValue == null || theValue.ToString() == "0")
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
