using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Classes
{
    internal abstract class Question
    {
        #region Properties
        public string Header { get; set; }
        public string Body { get; set; }
        public float Mark { get; set; }
        public Answer[] AnswersList { get; set; }
        public Answer RightAnswer { get; set; }
        #endregion

        #region Constructors
        protected Question(string _Header, string _Body, float _Mark, Answer _RightAnswer)
        {
            Header = _Header;
            Body = _Body;
            Mark = _Mark;
            AnswersList = new Answer[]
            {
                new Answer(1, "True"),
                new Answer(2, "False")
            };
            RightAnswer = _RightAnswer;
        }

        protected Question(string _Header, string _Body, float _Mark, Answer[] _AnswersList, Answer _RightAnswer) : this(_Header, _Body, _Mark, _RightAnswer)
        {
            AnswersList = _AnswersList;
        }
        #endregion

        #region Methods
        public void ShowQuestion()
        {
            Console.WriteLine($"{Header}\t\t{Mark} Marks");
            Console.WriteLine($"{Body}");

            if (AnswersList is not null)
            {
                foreach (Answer Answer in AnswersList)
                    Console.WriteLine(Answer);
            }
            Console.WriteLine();
        }
        #endregion
    }
}
