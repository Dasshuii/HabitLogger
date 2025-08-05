namespace HabitLogger.UI
{
    internal class Menu
    {
        public static void Show()
        {
            Console.WriteLine("MAIN MENU");
            Console.WriteLine("\n\nWhat would you like to do?");
            Console.WriteLine("\nType 0 to Close Application.");
            Console.WriteLine("\nType 1 to View All Records.");
            Console.WriteLine("\nType 2 to Insert Record.");
            Console.WriteLine("\nType 3 to Delete Record.");
            Console.WriteLine("\nType 4 to Update Record.");
            Console.WriteLine("------------------------------------------");
        }
    }
}
