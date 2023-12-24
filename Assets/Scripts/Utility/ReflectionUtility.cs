using System;
using System.Linq;
using System.Reflection;

namespace AG.DS
{
    public static class ReflectionUtility
    {
        public enum RetrieveDataType
        {
            All,
            Float,
            Double,
            Integer,
            String
        }

        /// <summary>
        /// Retrieve the field info from the type.
        /// </summary>
        /// 
        /// <param name="type">The type of the class to set for.</param>
        /// <param name="bindingFlags">The binding flags to set for.</param>
        /// <param name="retrieveDataType">The retrieve data type to set for.</param>
        /// 
        /// <returns>The field info from the given type.</returns>
        public static FieldInfo[] FieldInfos
        (
            this Type type,
            BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic,
            RetrieveDataType retrieveDataType = RetrieveDataType.All
        )
        {
            var result = type.GetFields(bindingFlags).AsEnumerable();

            if (retrieveDataType == RetrieveDataType.All)
            {
                return result.ToArray();
            }
            else
            {
                // Filter by data type
                var fieldType = retrieveDataType switch
                {
                    RetrieveDataType.Float => typeof(float),
                    RetrieveDataType.Double => typeof(double),
                    RetrieveDataType.Integer => typeof(int),
                    RetrieveDataType.String => typeof(string)
                };

                return result.Where(x => x.FieldType == fieldType).ToArray();
            }
        }
    }
}