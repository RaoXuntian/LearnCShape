using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    public interface IMathInfo
    {
        public string Director { get; set; }

        void GetScore();

        void SetScore(int score);

        void SetMathScore(int score);

        int GetMathScore();

        string GetMathTeacher();
    }
}
