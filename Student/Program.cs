using System;

namespace Student
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Person person = new();
            person.Gender = GenderCode.Male;
            Person P = new Student("Jack");
            Student stu = new Student("Milky");

            ((IChineseInfo)stu).SetScore(66);
            ((IChineseInfo)stu).GetScore();
            stu.GetChineseScore();
            Console.WriteLine("Chinese teacher is " + stu.GetChineseTeacher());
            Console.WriteLine("Math teacher is " + stu.GetMathTeacher());
        }
    }
}
