using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    public interface IChineseInfo
    {
        public string Director { get; set; }

        void GetScore();

        void SetScore(int score);

        void SetChineseScore(int score);

        int GetChineseScore();

        string GetChineseTeacher();

    }
}
