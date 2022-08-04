using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.Test
{
    public class RefTest
    {
        public class SomeRef
        {
            public int x;
        }

        public void Add(int x)
        {
            x++;
        }

        public void Add(ref int x)
        {
            x++;
        }

        public void Add(SomeRef r)
        {
            r.x++;
        }


        public void Test()
        {
            int v1 = 1;
            SomeRef r1 = new SomeRef();
            r1.x = 2;

            Console.WriteLine($"r1.x = {r1.x}\tv1 = {v1}");

            int v2 = v1;
            SomeRef r2 = r1;

            v2 = 5;
            r2.x = 6;
            Console.WriteLine($"r2.x = {r2.x}\tv2 = {v2}");
            Console.WriteLine("*************************************");
            Console.WriteLine($"r1.x = {r1.x}\tv1 = {v1}");

            Console.WriteLine("*************************************");
            Console.WriteLine("Call method Add(int x)");
            Add(v2);
            Add(r2.x);
            Console.WriteLine($"r2.x = {r2.x}\tv2 = {v2}");

            Console.WriteLine("*************************************");
            Console.WriteLine("Call method Add(ref int x)");
            Add(ref v2);
            Add(ref r2.x);
            Console.WriteLine($"r2.x = {r2.x}\tv2 = {v2}");

            Console.WriteLine("*************************************");
            Console.WriteLine($"r2.x = {r2.x}");
            Add(r2); // r2 is reference type in Add() method
            Console.WriteLine($"r2.x = {r2.x}");
        }
    }
}
