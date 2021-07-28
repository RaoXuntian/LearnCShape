using System;
using System.Collections.Generic;
//using HelloWorld;

namespace HelloWorld
{
    class Program
    {
        public static void ArrayPrint()
        {
            var grades = new int[] { 99, 80, 77, 66, 55, 44, 33, 22, 11 };
            for (int i = 0; i < grades.Length; i++)
            {
                Console.Write(grades[i] + "\t");
            }
            Console.WriteLine();
            foreach (var grade in grades)
            {
                Console.WriteLine(grade);
            }
        }
        static void Main(string[] args)
        {
            //var str = "Welcome to Microsoft!";

            //Console.WriteLine("Please input your name:");
            //var anything = Console.ReadLine();

            //Console.WriteLine("Hello " + anything + ", " + str);
            //Console.WriteLine("Hello {0}, {1}", anything, str);

            //ArrayPrint();

            var gg = new GenGuid();
            gg.GenGuid2();
            var gg1 = gg.SetGuid();
            var gg2 = gg.SetGuidRandom();
            var gg3 = gg.SetGuidRandom();
            Console.WriteLine($"Guid1 is {gg1}.");
            Console.WriteLine($"Guid2 is {gg2}.");
            Console.WriteLine($"Guid3 is {gg3}.");

            //var atest = new TestClass();
            TestClass.GenObj();

            //var enumtest = new EnumTest();
            //enumtest.Main();

            Symbol.wenhao();

            Console.Write("Input tablename: ");
            string tablename = Console.ReadLine();

            while(!string.IsNullOrWhiteSpace(tablename))
            {
                //var tablelist = TableIdentifierHelper.SplitIdentifier(tablename);
                var tablelist = TableIdentifierHelper.SplitIdentifierForOracle(tablename);
                if (tablelist != null)
                {
                    string schema = string.Join(".", tablelist, 0, tablelist.Length - 1);
                    string table = tablelist[tablelist.Length - 1];
                    Console.WriteLine($"schema:\t{schema}\ntable:\t{table}");
                    //foreach (var item in tablelist)
                    //{
                    //    Console.WriteLine(item);
                    //}
                }
                else
                {
                    Console.WriteLine("input ERROR!!!");
                }
                Console.Write("Input tablename again: ");
                tablename = Console.ReadLine();
            }


            Console.ReadLine();
        }
    }
}
