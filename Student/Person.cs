using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    public enum GenderCode
    {
        Male = 0,
        Female = 1,
        Neutral = 2
    }

    public enum CountryCode
    {
        China,
        US,
        JPN,
        KOR,
        UK,
        Singapore,
    }

    public class Person
    {
        public long IdNumber { get; set; }

        public int BirthYears { get; set; }

        public int Olds { get; set; }

        public CountryCode Country { get; set; }

        public string Name { get; set; }

        public GenderCode Gender { get; set; }

        public Person()
        {
            
        }

        public Person(string name)
        {
            Console.WriteLine($"Hi all, This is {name}");
            this.Name = name;
        }

        
    }
}
