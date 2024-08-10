using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Classes
{
    internal abstract class InputValidation
    {
        #region Methods
        public static int CheckIntInput(string message, string messageIfCastingFails, int minCheck, int? maxCheck = null)
        {
            int userInput;
            bool flag, loopFlag;
            do
            {
                Console.WriteLine(message);
                flag = int.TryParse(Console.ReadLine(), out userInput);

                if (maxCheck is not null)
                {
                    loopFlag = !flag || userInput < minCheck || userInput > maxCheck;

                    if (loopFlag)
                        Console.WriteLine($"{messageIfCastingFails}...\n");
                }
                else
                {
                    loopFlag = !flag || userInput <= minCheck;

                    if (loopFlag)
                        Console.WriteLine($"{messageIfCastingFails}...\n");
                }

            } while (loopFlag);

            return userInput;
        }

        public static string CheckEmptyString(string message)
        {
            string input;
            do
            {
                Console.WriteLine(message);
                input = Console.ReadLine()?.Trim() ?? string.Empty;

                if (string.IsNullOrEmpty(input))
                    Console.WriteLine("\nInput cannot be empty. Please try again.\n");

            } while (string.IsNullOrEmpty(input));

            return input;
        } 
        #endregion
    }
}
