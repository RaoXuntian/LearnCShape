using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keywords
{
    public class ClassRef
    {
        public static void AddOne<T>(ref T number)
        {
            RefFunction<T>(ref number);
        }

        public static void RefFunction<T>(ref T number)
        {
            try
            {
                T one = (T)Convert.ChangeType(1, typeof(T));
                if (Helper.IsInt<T>())
                {
                    int a = (int)Convert.ChangeType(number, typeof(int));
                    a += 1;
                    number = (T)Convert.ChangeType(a, typeof(T));
                }
                else if (Helper.IsDouble<T>())
                {
                    double a = (double)Convert.ChangeType(number, typeof(double));
                    a += 1;
                    number = (T)Convert.ChangeType(a, typeof(T));
                }
                else if (Helper.IsFloat<T>())
                {
                    float a = (float)Convert.ChangeType(number, typeof(float));
                    a += 1;
                    number = (T)Convert.ChangeType(a, typeof(T));
                }
                else if (Helper.IsLong<T>())
                {
                    long a = (long)Convert.ChangeType(number, typeof(long));
                    a += 1;
                    number = (T)Convert.ChangeType(a, typeof(T));
                }
                else
                {
                    Console.WriteLine("The type of input is Unsupported!");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
   
        }

        public static void OutFunction(out int number)
        {
            number = 100;
        }

    }
}
