using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LoggerTask
{
    public class ObjectToStringConverter
    {
        private string _propertyAttributeName;
        private string _propertyValue;
        private string _fieldAttributeName;
        private string _fieldValue;
        public string ConvertToString(object obj)
        {
            var sb = new StringBuilder();
            var classAttributes = obj.GetType().GetCustomAttributes(true);
            foreach (var classAttibute in classAttributes)
            {
                if (classAttibute is TrackingEntityAttribute)
                {
                    foreach (var property in obj.GetType().GetProperties())
                    {
                        _propertyAttributeName = ((TrackingPropertyAttribute)property.GetCustomAttribute(typeof(TrackingPropertyAttribute)))?.Name;
                        _propertyValue = property.GetValue(obj).ToString();
                        if (_propertyAttributeName is null)
                        {
                            _propertyAttributeName = property.Name;
                        }
                        sb.AppendJoin(" = ", _propertyAttributeName, _propertyValue);
                    }
                    foreach (var field in obj.GetType().GetFields())
                    {
                        _fieldAttributeName = ((TrackingPropertyAttribute)field.GetCustomAttribute(typeof(TrackingPropertyAttribute)))?.Name;
                        _fieldValue = field.GetValue(obj).ToString();
                        if (_fieldAttributeName is null)
                        {
                            _fieldAttributeName = field.Name;
                        }
                        sb.AppendJoin(" = ", _fieldAttributeName, _fieldValue);
                    }
                }
            }
            return sb.ToString();
        }
    }
}
