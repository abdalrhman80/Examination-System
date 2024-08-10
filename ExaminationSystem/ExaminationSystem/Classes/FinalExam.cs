using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Classes
{
    internal class FinalExam : Exam
    {
        #region Constructor
        public FinalExam(int _Time, int _QuestionsNumber, Question[] _Questions) : base(_Time, _QuestionsNumber, _Questions)
        {
        }
        #endregion

        #region Methods
        public override void ShowExam()
        {
            Console.Clear();
            Console.WriteLine("Final Exam:-\n");

            float grade = 0;

            List<string> userAnswers = new List<string>();

            for (int i = 0; i < Questions.Length; i++)
            {
                Questions[i].ShowQuestion();

                int userAnswerId;
                bool flag, loopFlag;

                do
                {
                    Console.Write("Your AnswerId: ");
                    flag = int.TryParse(Console.ReadLine(), out userAnswerId);

                    if (userAnswerId == 3)
                    {
                        loopFlag = !flag || userAnswerId <= 0 || userAnswerId >= 3;

                        if (loopFlag)
                            Console.WriteLine("\nInvalid AnswerId...\n");
                        else
                            userAnswers .Add(Questions[i].AnswersList[userAnswerId - 1].AnswerText ?? ".....");
                    }
                    else
                    {
                        loopFlag = !flag || userAnswerId <= 0 || userAnswerId > 3;

                        if (loopFlag)
                            Console.WriteLine("\nInvalid AnswerId...\n");
                        else
                            userAnswers .Add(Questions[i]?.AnswersList?[userAnswerId - 1]?.AnswerText ?? ".....");
                    }

                } while (loopFlag);

                Console.WriteLine();

                if (userAnswerId == Questions[i]?.RightAnswer?.AnswerID)
                    grade++;
            }

            Console.Clear();

            for (int i = 0; i < Questions.Length; i++)
            {
                int rightAnswerId = Questions[i].RightAnswer.AnswerID;

                Console.WriteLine($"Question{i + 1}: {Questions[i]}");
                Console.WriteLine($"Your Answer => {userAnswers[i]}");
                Console.WriteLine($"Right Answer => {Questions[i].AnswersList[rightAnswerId - 1].AnswerText}\n");
            }

            Console.WriteLine($"Your Grade is {grade} Of {Questions.Length}\n");
        }
        #endregion
    }
}
