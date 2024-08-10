using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Classes
{
    internal class MCQ : Question
    {
        public MCQ(string _Header, string _Body, float _Mark, Answer[] _AnswersList, Answer _RightAnswer) : base(_Header, _Body, _Mark, _AnswersList, _RightAnswer)
        {
        }

        public override string ToString()
        {
            return Body ?? string.Empty;
        }
    }
}
