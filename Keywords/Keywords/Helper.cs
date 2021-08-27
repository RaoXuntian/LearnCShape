using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keywords
{
    public class Helper
    {
        public static bool IsTheSameType<T1, T2>()
        {
            return typeof(T1) == typeof(T2);
        }

        public static bool IsInt<T>()
        {
            return IsTheSameType<T, int>();
        }

        public static bool IsDouble<T>()
        {
            return IsTheSameType<T, double>();
        }

        public static bool IsFloat<T>()
        {
            return IsTheSameType<T, float>();
        }

        public static bool IsLong<T>()
        {
            return IsTheSameType<T, long>();
        }
    }
}
