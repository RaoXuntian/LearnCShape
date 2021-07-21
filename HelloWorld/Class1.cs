using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    public class Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y) => (X, Y) = (x, y);
    }

    public class Pair<TFirst, TSecond>
    {
        public TFirst First { get; }
        public TSecond Second { get; }

        public Pair(TFirst first, TSecond second) =>
            (First, Second) = (first, second);
    }

    public class TestClass
    {
        public static void GenObj()
        //Use static keyword definition Method/functions in the class,
        //we can directly call function by [ClassName.MethodName] without instantiation.
        //Non-static methods need to instantiate an object first, then call the [ObjectName.MethodName()].
        {
            var p1 = new Point(0, 0);
            var p2 = new Point(10, 20);

            Console.WriteLine("({0}, {1})", p1.X, p1.Y);
            Console.WriteLine($"({p2.X}, {p2.X})");

            var pair = new Pair<int, string>(1, "two");
            int ii = pair.First;     // TFirst int
            string s = pair.Second; // TSecond string
            Console.WriteLine(ii + s);

            var pair2 = new Pair<string, string>("Cheung", "Leslie");
            Console.WriteLine(pair2.Second + pair2.First);

            var Person2City = new Dictionary<string, string>() { { "Jack", "Wuhan" }, { "Milky", "Shanghai" } };
            foreach (var item in Person2City)
            {
                Console.WriteLine($"{item.Key} works in {item.Value}.");
            }
            IDictionary<string, string> idc = new Dictionary<string, string>(Person2City);
            foreach (var item in idc)
            {
                Console.WriteLine($"{item.Key} works in {item.Value} again.");
            }
        }
    }

    
}
