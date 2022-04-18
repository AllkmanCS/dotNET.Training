using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LoggerTask
{
    public static class ObjectToStringConverter
    {
        public static string ConvertToString(object obj)
        {
            var sb = new StringBuilder();
            var classAttributes = obj.GetType().GetCustomAttributes(true);
            foreach (var classAttibute in classAttributes)
            {
                if (classAttibute is TrackingEntityAttribute)
                {
                    foreach (var property in obj.GetType().GetProperties())
                    {
                        string propertyAttributeName = ((TrackingPropertyAttribute)property.GetCustomAttribute(typeof(TrackingPropertyAttribute)))?.Name;
                        string propertyValue = property.GetValue(obj).ToString();
                        if (propertyAttributeName is null)
                        {
                            propertyAttributeName = property.Name;
                        }
                        sb.AppendJoin(" = ", propertyAttributeName, propertyValue);
                    }
                    foreach (var field in obj.GetType().GetFields())
                    {
                        string fieldAttributeName = ((TrackingPropertyAttribute)field.GetCustomAttribute(typeof(TrackingPropertyAttribute)))?.Name;
                        string fieldValue = field.GetValue(obj).ToString();
                        if (fieldAttributeName is null)
                        {
                            fieldAttributeName = field.Name;
                        }
                        sb.AppendJoin(" = ", fieldAttributeName, fieldValue);
                    }
                }
            }
            return sb.ToString();
        }
    }
}
