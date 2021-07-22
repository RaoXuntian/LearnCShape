using System;

namespace HelloWorld
{
    class Symbol
    {
        public static void wenhao()
        {
            int i = new int(); // default value is 0
            int? ii = new int?(); // default value is null
            Console.WriteLine(value: $"i is {i}.\nii is {ii}.");

            int? num1 = null;
            int? num2 = 45;
            double? num3 = new double?();
            double? num4 = 3.14157;

            bool? boolval = new bool?();

            // 显示值

            Console.WriteLine("Display the values of the nullable type: {0}, {1}, {2}, {3}",
                               num1, num2, num3, num4);
            Console.WriteLine("A nullable Boolean value: {0}", boolval);
            //Console.ReadLine();

            double num5;
            num5 = num3 ?? 10.37;
            Console.WriteLine("num5 的值： {0}", num5);

            num5 = num4 ?? 10.37;
            Console.WriteLine("num5 的值： {0}", num5);
        }
    }
}