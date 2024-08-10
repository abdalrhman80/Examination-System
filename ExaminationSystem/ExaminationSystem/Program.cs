using ExaminationSystem.Classes;

namespace ExaminationSystem
{
    internal class Program
    {
        public static void ExamInformation(out int examType, out int examTime, out int questionNumbers)
        {
            examType = InputValidation.CheckIntInput("Please Enter Type Of Exam (1 For Practical | 2 For Final)", "Invalid Exam Type Number", 1, 2);

            examTime = InputValidation.CheckIntInput("\nPlease Enter The Time For Exam (30 min to 180 min)", "Invalid Exam Time Number", 30, 180);

            questionNumbers = InputValidation.CheckIntInput("\nPlease Enter The Number Of Questions", "Invalid Questions Number", 0);
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Examination System..\n");
            ExamInformation(out int examType, out int examTime, out int questionNumbers);

            Console.Clear();

            Subject subject = new Subject();
            Exam subjectExam = subject.CreateExam(examType, examTime, questionNumbers);

            while (true)
            {
                Console.WriteLine("Do You Want Start Exam (Y|N)");
                string startExam = Console.ReadLine() ?? "n";

                if (startExam == "Y" || startExam == "y")
                {
                    subjectExam.ShowExam();
                    break;
                }
                else if (startExam == "N" || startExam == "n")
                    break;
            }

            Console.WriteLine("\nThank You :)\n");
        }
    }
}
