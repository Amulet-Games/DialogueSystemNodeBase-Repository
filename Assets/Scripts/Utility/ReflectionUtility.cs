using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;

namespace AG.DS
{
    public static class ReflectionUtility
    {
        /// <summary>
        /// Retrieve the field info from the type.
        /// </summary>
        /// <param name="type">The type of the class to set for.</param>
        /// <param name="bindingFlags">The binding flags to set for.</param>
        /// <returns>The IEnumberable of field info from the given type.</returns>
        public static IEnumerable<FieldInfo> GetFieldInfo
        (
            this Type type,
            BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic
        )
        {
            return type.GetFields(bindingFlags).AsEnumerable();
        }


        /// <summary>
        /// Filter the field info with number type.(int, float, double).
        /// </summary>
        /// <param name="fieldInfo">The IEnumerable of field info to set for.</param>
        /// <returns>The IEnumberable of field info filtered with number type.</returns>
        public static IEnumerable<FieldInfo> FilterWithNumberType(this IEnumerable<FieldInfo> fieldInfo)
        {
            return fieldInfo.Where(x => x.FieldType == typeof(int)
                                     || x.FieldType == typeof(float)
                                     || x.FieldType == typeof(double));
        }


        /// <summary>
        /// Filter the field info with string type.
        /// </summary>
        /// <param name="fieldInfo">The IEnumerable of field info to set for.</param>
        /// <returns>The IEnumberable of field info filtered by string type.</returns>
        public static IEnumerable<FieldInfo> FilterWithStringType(this IEnumerable<FieldInfo> fieldInfo)
        {
            return fieldInfo.Where(x => x.FieldType == typeof(string));
        }


        /// <summary>
        /// Retrieve the property info from the type.
        /// </summary>
        /// <param name="type">The type of the class to set for.</param>
        /// <param name="bindingFlags">The binding flags to set for.</param>
        /// <returns>The IEnumberable of property info from the given type.</returns>
        public static IEnumerable<PropertyInfo> GetPropertyInfo
        (
            this Type type,
            BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic
        )
        {
            return type.GetProperties(bindingFlags).AsEnumerable();
        }


        /// <summary>
        /// Filter the property info with number type.(int, float, double).
        /// </summary>
        /// <param name="propertyInfo">The IEnumerable of property info to set for.</param>
        /// <returns>The IEnumberable of property info filtered with number type.</returns>
        public static IEnumerable<PropertyInfo> FilterWithNumberType(this IEnumerable<PropertyInfo> propertyInfo)
        {
            return propertyInfo.Where(x => x.PropertyType == typeof(int)
                                        || x.PropertyType == typeof(float)
                                        || x.PropertyType == typeof(double));
        }


        /// <summary>
        /// Filter the property info with string type.
        /// </summary>
        /// <param name="propertyInfo">The IEnumerable of property info to set for.</param>
        /// <returns>The IEnumberable of property info filtered by string type.</returns>
        public static IEnumerable<PropertyInfo> FilterWithStringType(this IEnumerable<PropertyInfo> propertyInfo)
        {
            return propertyInfo.Where(x => x.PropertyType == typeof(string));
        }


        /// <summary>
        /// Filter the property info with readable.
        /// </summary>
        /// <param name="propertyInfo">The IEnumerable of property info to set for.</param>
        /// <returns>The IEnumberable of property info filtered with readable.</returns>
        public static IEnumerable<PropertyInfo> FilterWithReadable(this IEnumerable<PropertyInfo> propertyInfo)
        {
            return propertyInfo.Where(x => x.CanRead);
        }


        /// <summary>
        /// Filter the property info with writable.
        /// </summary>
        /// <param name="propertyInfo">The IEnumerable of property info to set for.</param>
        /// <returns>The IEnumberable of property info filtered with writable.</returns>
        public static IEnumerable<PropertyInfo> FilterWithWritable(this IEnumerable<PropertyInfo> propertyInfo)
        {
            return propertyInfo.Where(x => x.CanWrite);
        }
    }
}