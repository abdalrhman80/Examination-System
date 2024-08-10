using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Classes
{
    internal abstract class Exam
    {
        #region Properties
        public int Time { get; set; }
        public int QuestionsNumber { get; set; }
        public Question[] Questions { get; set; }
        #endregion

        #region Constructors
        protected Exam(int _Time, int _QuestionsNumber, Question[] _Questions)
        {
            Time = _Time;
            QuestionsNumber = _QuestionsNumber;
            Questions = _Questions;
        }
        #endregion

        #region Methods
        public abstract void ShowExam(); // This method will be implemented differently in FinalExam and PracticalExam 
        #endregion
    }
}
