using System;
using System.Linq;
using System.Reflection;

namespace AG.DS
{
    public static class ReflectionUtility
    {
        /// <summary>
        /// Retrieve the field info of the class.
        /// </summary>
        /// 
        /// <param name="type">The type of the class to set for.</param>
        /// <param name="reflectionFieldType">The reflection field type to set for.</param>
        /// 
        /// <returns>The field info of the class.</returns>
        /// 
        /// <exception cref="ArgumentException">
        /// Thrown when the either the given reflection field type or reflection data type is invalid to any of the current existing reflection's type.
        /// </exception>
        public static FieldInfo[] FieldInfos
        (
            this Type type,
            ReflectionFieldType reflectionFieldType = ReflectionFieldType.Public_Private_Instance_Static,
            ReflectionDataType reflectionDataType = ReflectionDataType.None
        )
        {
            var fieldInfo = reflectionFieldType switch
            {
                ReflectionFieldType.Public => type.GetFields(BindingFlags.Public),
                ReflectionFieldType.Private => type.GetFields(BindingFlags.NonPublic),
                ReflectionFieldType.Instance => type.GetFields(BindingFlags.Instance),
                ReflectionFieldType.Static => type.GetFields(BindingFlags.Static),

                ReflectionFieldType.Public_Private => type.GetFields(BindingFlags.Public | BindingFlags.NonPublic),
                ReflectionFieldType.Public_Instance => type.GetFields(BindingFlags.Public | BindingFlags.Instance),
                ReflectionFieldType.Public_Static => type.GetFields(BindingFlags.Public | BindingFlags.Static),

                ReflectionFieldType.Public_Private_Instance =>
                    type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance),

                ReflectionFieldType.Public_Private_Static =>
                    type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static),

                ReflectionFieldType.Public_Private_Instance_Static =>
                    type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static),

                ReflectionFieldType.Public_Instance_Static =>
                    type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static),

                ReflectionFieldType.Private_Instance => type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance),
                ReflectionFieldType.Private_Static => type.GetFields(BindingFlags.NonPublic | BindingFlags.Static),

                ReflectionFieldType.Private_Instance_Static =>
                    type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static),

                ReflectionFieldType.Instance_Static => type.GetFields(BindingFlags.Instance | BindingFlags.Static),

                _ => throw new ArgumentException("Invalid reflection field type: " + reflectionFieldType)
            };

            if (reflectionDataType == ReflectionDataType.None)
            {
                return fieldInfo;
            }

            // Filter by data type
            {
                var fieldType = reflectionDataType switch
                {
                    ReflectionDataType.Float => typeof(float),
                    ReflectionDataType.Double => typeof(double),
                    ReflectionDataType.Integer => typeof(int),
                    ReflectionDataType.String => typeof(string),
                    _ => throw new ArgumentException("Invalid reflection data type: " + reflectionDataType)
                };

                return (FieldInfo[])fieldInfo.Where(x => x.FieldType == fieldType);
            }
        }
    }
}