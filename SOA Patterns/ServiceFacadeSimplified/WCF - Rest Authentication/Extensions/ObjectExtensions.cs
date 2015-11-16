using System;
using System.ComponentModel;

namespace WcfRestAuthentication.Extensions
{
    internal static class ObjectExtensions
    {
        public static bool TryConvertTo(this object value, Type type, out object result)
        {
            result = value;
            var stringVal = Convert.ToString(value);

            if (string.IsNullOrWhiteSpace(stringVal))
                return true;

            try
            {
                var converter = TypeDescriptor.GetConverter(type);
                result = converter.ConvertFromString(stringVal);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}