using System;
using HelloWorld;

namespace Keywords
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //HelloWorld.Program.ArrayPrint();

            int count = 2147483647;
            float floatNum = 1.1F;
            double doubleNum = 2.2;
            long longNum = 10000;
            Console.WriteLine($"count = {count}");
            ClassRef.AddOne<int>(ref count);
            Console.WriteLine($"count = {count}");

            ClassRef.AddOne<float>(ref floatNum);
            Console.WriteLine($"floatNum = {floatNum}");

            ClassRef.AddOne<double>(ref doubleNum);
            Console.WriteLine($"doubleNum = {doubleNum}");

            ClassRef.AddOne<long>(ref longNum);
            Console.WriteLine($"longNum = {longNum}");

            ClassRef.OutFunction(out int outNum);
            Console.WriteLine($"count = {outNum}");

            string str = "hahahah";
            ClassRef.AddOne<string>(ref str);

            Console.WriteLine(typeof(float) == typeof(double));
            Console.WriteLine(typeof(Int64) == typeof(long));
            Console.WriteLine(longNum is Int64);

            {
                Child child = new();
                Parents parent = new();
                Console.WriteLine(typeof(Parents) == typeof(Child));    // False
                Console.WriteLine(child is Parents);    // True
                Console.WriteLine(parent is Child);     // False
                Console.WriteLine(child.GetType() == typeof(Parents));  // False

                Parents pp = child as Parents;  // pp != null
                Console.WriteLine(pp != null ? "Child can transfer to Parents": "Child can not transfer to Parents");

                Child cc = parent as Child;     // cc == null
                Console.WriteLine(cc != null ? "Parents can transfer to Child": "Parents can not transfer to Child");
            }
        }
    }

    public class Parents
    {
        public Parents()
        {
            Console.WriteLine("This is a Parents.");
        }

        ~Parents()
        {
            Console.WriteLine("Bye Parents~");
        }
    }

    class Child: Parents
    {
        public Child()
        {
            Console.WriteLine("This is a Child.");
        }

        ~Child()
        {
            Console.WriteLine("Bye child~");
        }
    }
}
