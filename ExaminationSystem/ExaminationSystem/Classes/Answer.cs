using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Classes
{
    internal class Answer
    {
        #region Properties
        public int AnswerID { get; set; }
        public string? AnswerText { get; set; }
        #endregion

        #region Constructor
        public Answer(int _AnswerID)
        {
            AnswerID = _AnswerID;
        }
        public Answer(int _AnswerID, string? _AnswerText) : this(_AnswerID)
        {
            AnswerText = _AnswerText;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{AnswerID}- {AnswerText}";
        }
        #endregion
    }
}
