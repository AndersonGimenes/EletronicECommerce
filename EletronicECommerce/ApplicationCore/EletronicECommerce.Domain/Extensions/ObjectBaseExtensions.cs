using System.Collections.Generic;

namespace EletronicECommerce.Domain.Extensions
{
    public static class ObjectBaseExtensions
    {
        public static void SetValuesProperties(this object obj, Dictionary<string, dynamic> values) 
        {
            foreach(var value in values)
            {
                obj.GetType().GetProperty(value.Key).SetValue(obj, value.Value);
            }
        }	
    }
}