using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Classes
{
    internal class PracticalExam : Exam
    {
        #region Constructor
        public PracticalExam(int _Time, int _QuestionsNumber, Question[] _Questions) : base(_Time, _QuestionsNumber, _Questions)
        {
        }
        #endregion

        #region Methods
        public override void ShowExam()
        {
            Console.Clear();
            Console.WriteLine("Practical Exam:-\n");

            for (int i = 0; i < Questions.Length; i++)
            {
                Questions[i].ShowQuestion();

                int userAnswerId;
                bool flag;

                do
                {
                    Console.Write("Your AnswerId: ");
                    flag = int.TryParse(Console.ReadLine(), out userAnswerId);

                    if (!flag || userAnswerId <= 0 || userAnswerId > 3)
                        Console.WriteLine("\nInvalid AnswerId...\n");

                } while (!flag || userAnswerId <= 0 || userAnswerId > 3);

                Console.WriteLine();
            }

            Console.Clear();

            for (int i = 0; i < Questions?.Length; i++)
            {
                if (Questions is not null)
                {
                    int rightAnswerId = Questions[i].RightAnswer.AnswerID;

                    Console.WriteLine($"Question{i + 1}: {Questions[i]}");
                    Console.WriteLine($"Right Answer => {Questions[i].AnswersList[rightAnswerId - 1].AnswerText}\n");
                }
            }
        }
        #endregion
    }
}
