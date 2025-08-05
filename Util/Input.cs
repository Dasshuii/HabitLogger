using System.Globalization;

namespace HabitLogger.Util
{
    internal class Input
    {
        public static string GetUserInput(string prompt)
        {
            Console.WriteLine(prompt);
            string? input = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(input) || input == null)
            {
                Console.WriteLine("Invalid input. Try again.");
                input = Console.ReadLine();
            }
            return input.Trim();
        }
        
        public static int GetIntegerInput(string prompt)
        {
            string? input = GetUserInput(prompt);
            int result = 0;
            while (!int.TryParse(input, out result))
            {
                Console.WriteLine("Your input must be a number. Try again.");
                input = Console.ReadLine();
            }
            return result;
        }
        public static DateTime GetDateInput(string prompt, string format)
        {
            string input = GetUserInput(prompt);
            DateTime date;
            while(!DateTime.TryParseExact(input, format, new CultureInfo("en-US"), DateTimeStyles.None, out date)) {
                if (input == "1")
                {
                    date = DateTime.Now;
                    break;
                }
                Console.WriteLine("Invalid date. Try again. Format (dd-mm-yy).");
                input = GetUserInput(prompt);
            }
            return date;
        }
    }
}
