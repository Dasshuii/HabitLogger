using HabitLogger;
using HabitLogger.Data;
using HabitLogger.UI;
using HabitLogger.Util;
using SQLitePCL;

internal class Program
{
    public static void Main(string[] args)
    {
        Batteries.Init();
        DatabaseManager.CreateTables();

        bool exit = false;

        do
        {
            Menu.Show();
            int opt = Input.GetIntegerInput("Opt");

            switch (opt)
            {
                case 0:
                    exit = true;
                    break;
                case 1:
                    DrinkingManager.ShowDrinkingLog();
                    break;
                case 2:
                    DatabaseManager.InsertRecord(DrinkingManager.CreateRecord());
                    break;
                case 3:
                    DrinkingManager.DeleteRecord();
                    break;
                case 4:
                    DrinkingManager.UpdateRecord();
                    break;
                default:
                    Console.WriteLine("Invalid input. Please type a number between 0 and 4.");
                    break;
            }
        } while (!exit);
    }
}