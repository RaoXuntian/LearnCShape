using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    public class Student: Person, IChineseInfo, IMathInfo
    {
        private string ChineseTeacher;
        private string MathTeacher;
        private int ChineseScore = -1;
        private int MathScore = -1;
        public Student()
        {

        }

        public Student(string name)
        {
            Console.WriteLine($"Hi, this is student {name}.");
            this.Name = name;
            this.MathTeacher = "RXT";
        }

        void Init()
        {
            ChineseScore = -1;
            MathScore = -1;
        }

        string IChineseInfo.Director { get; set; }

        string IMathInfo.Director { get; set; }

        void IChineseInfo.GetScore()
        {
            if (JudgeScoreOK(ChineseScore))
            {
                Console.WriteLine($"Your Chinese score is {ChineseScore}");
            }
            else
            {
                Console.WriteLine("The score is wrong!");
            }
        }

        void SetScoreInternal(ref int target, int score)
        {
            int n = 3;
            while (--n > 0)
            {
                if (JudgeScoreOK(score))
                {
                    target = score;
                    return;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("The score should in the scope between 0 and 100.");
                    Console.WriteLine($"You have {n} times to input the score again.");
                    Console.Write("Please input the score again:");
                    var input = Console.ReadLine();
                    try
                    {
                        score = int.Parse(input);
                        target = score;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        score = -1;
                        if (n < 2)
                        {
                            Console.WriteLine("Bye :)");
                        }
                    }
                }
            }
        }

        void IChineseInfo.SetScore(int score)
        {
            SetScoreInternal(ref ChineseScore, score);
        }

        void IMathInfo.GetScore()
        {
            if (JudgeScoreOK(MathScore))
            {
                Console.WriteLine($"Your Math score is {MathScore}");
            }
            else
            {
                Console.WriteLine("The score is wrong!");
            }
        }

        void IMathInfo.SetScore(int score)
        {
            SetScoreInternal(ref MathScore, score);
        }

        public void SetChineseScore(int score)
        {
            SetScoreInternal(ref ChineseScore, score);
        }

        public void SetMathScore(int score)
        {
            SetScoreInternal(ref MathScore, score);
        }

        public string? GetChineseTeacher()
        {
            return ChineseTeacher;
        }

        public int GetChineseScore()
        {
            return ChineseScore;
        }

        public string? GetMathTeacher()
        {
            return MathTeacher;
        }

        public int GetMathScore()
        {
            return MathScore;
        }

        bool JudgeScoreOK(int score)
        {
            if (score < 0 || score > 100)
            {
                return false;
            }
            return true;
        }

    }
}
