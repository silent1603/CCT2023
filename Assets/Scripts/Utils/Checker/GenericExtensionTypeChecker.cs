using System;

namespace Utils
{
    namespace Checker
    {
        public static class TypeExtensions
        {
            public static bool IsNumericType<T>()
            {
                Type type = typeof(T);
                return IsNumericType(type);
            }

            public static bool IsNumericType(this Type type)
            {
                if (type == null)
                {
                    throw new ArgumentNullException(nameof(type));
                }

                // Check if the type is numeric by comparing it with common numeric types.
                return type == typeof(byte) ||
                       type == typeof(sbyte) ||
                       type == typeof(short) ||
                       type == typeof(ushort) ||
                       type == typeof(int) ||
                       type == typeof(uint) ||
                       type == typeof(long) ||
                       type == typeof(ulong) ||
                       type == typeof(float) ||
                       type == typeof(double) ||
                       type == typeof(decimal);
            }
        }
    }

}