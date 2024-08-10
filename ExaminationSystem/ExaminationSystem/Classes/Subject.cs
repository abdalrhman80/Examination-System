using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Classes
{
    internal class Subject
    {
        #region Properties
        public int SubjectId { get; set; }
        public string? SubjectName { get; set; }
        public Exam? SubjectExam { get; set; }
        #endregion

        #region Constructors
        public Subject() { }

        public Subject(int _SubjectId, string _SubjectName, Exam _SubjectExam)
        {
            SubjectId = _SubjectId;
            SubjectName = _SubjectName;
            SubjectExam = _SubjectExam;
        }
        #endregion

        #region Methods
        public Exam CreateExam(int examType, int examTime, int questionNumbers)
        // This could return either a FinalExam or PracticalExam based what Exam Will Choose
        {
            Question[] Questions = new Question[questionNumbers];

            for (int i = 0; i < questionNumbers; i++)
            {
                if (examType == 1) // PracticalExam
                {
                    Questions[i] = CreateMCQ();

                    SubjectExam = new PracticalExam(examTime, questionNumbers, Questions);
                }
                else if (examType == 2) // FinalExam
                {
                    int questionsType = InputValidation.CheckIntInput("Please Enter Type Of Questions (1 For MCQ | 2 For True Or False)", "Invalid Questions Type Number", 1, 2);

                    Console.Clear();

                    Questions[i] = questionsType == 1 ? CreateMCQ() : CreateTrueFalseQuestion();

                    SubjectExam = new FinalExam(examTime, questionNumbers, Questions);
                }
            }

            return SubjectExam ?? throw new Exception("No Exam! Check What Is The Wrong In The Process..\n");
        }

        private MCQ CreateMCQ()
        {
            Console.WriteLine("MCQ Question: \n");

            string questionBody = InputValidation.CheckEmptyString("Please Enter Question Body");

            int questionMark = InputValidation.CheckIntInput("\nPlease Enter Question Mark", "Mark Should Be Number Greater Than 0", 0);

            Console.WriteLine("Choices Of Question\n");

            string choice1 = InputValidation.CheckEmptyString("Choice Number 1: ");
            string choice2 = InputValidation.CheckEmptyString("Choice Number 2: ");
            string choice3 = InputValidation.CheckEmptyString("Choice Number 3: ");

            Answer[] answers = new Answer[3]
            {
               new Answer (1, choice1),
               new Answer (2, choice2),
               new Answer (3, choice3)
            };

            int mcqRightAnswerId = InputValidation.CheckIntInput("What Is The Right Answer Id?", "Answer Should Be From 1 To 3", 1, 3);

            Console.Clear();

            return new MCQ("MCQ Question", questionBody ?? "....", questionMark, answers, new Answer(mcqRightAnswerId));
        }

        private TFQ CreateTrueFalseQuestion()
        {
            Console.WriteLine("True Or False Question\n");

            string questionBody = InputValidation.CheckEmptyString("Please Enter Question Body");

            int questionMark = InputValidation.CheckIntInput("Please Enter Question Mark", "Mark Should Be Number Greater Than 0", 0);

            int trueFalseRightAnswerId = InputValidation.CheckIntInput("What Is The Right Answer Id (1 For True | 2 For False)", "Answer Should Be 1 Or 2", 1, 2);

            Console.Clear();

            return new TFQ("True or False Question", questionBody ?? "....", questionMark, new Answer(trueFalseRightAnswerId));
        }
        #endregion
    }
}