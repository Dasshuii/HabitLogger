using HabitLogger;
using SQLitePCL;
using System.Globalization;

internal class Program
{
    public static void Main(string[] args)
    {
        //DateTime date;
        //bool fecha = DateTime.TryParseExact("22-10-2002", "dd-mm-yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out date);
        //Console.WriteLine(fecha);
        //Console.WriteLine(date.ToShortDateString());
        Batteries.Init();
        DatabaseManager databaseManager = new();
        databaseManager.CreateTables();

        Console.WriteLine("MAIN MENU");
        Console.WriteLine("\n\nWhat would you like to do?");
        Console.WriteLine("\nType 0 to Close Application.");
        Console.WriteLine("\nType 1 to View All Records.");
        Console.WriteLine("\nType 2 to Insert Record.");
        Console.WriteLine("\nType 3 to Delete Record.");
        Console.WriteLine("\nType 4 to Update Record.");
        Console.WriteLine("------------------------------------------");

        int opt = int.Parse(Console.ReadLine());

        switch (opt)
        {
            case 0:
                break;
            case 1:
                List<DrinkWater> records = databaseManager.GetDrinkWaterLog();
                foreach (DrinkWater record in records)
                    Console.WriteLine(record);
                break;
            case 2:
                string format = "dd-mm-yy";
                Console.WriteLine($"Please insert date: (Format: {format}). Type 1 to Today's Date and 0 to return to main menu.");
                string? dateInput = Console.ReadLine();
                DateTime date;
                while (!DateTime.TryParseExact(dateInput, format, new CultureInfo("en-US"), DateTimeStyles.None, out date))
                {
                    if (dateInput == "1")
                    {
                        date = DateTime.Now;
                        break;
                    }
                    dateInput = Console.ReadLine();
                    Console.WriteLine("Invalid date. Try again.");
                }

                Console.WriteLine("Please insert the number of glasses or other measure of your choice.");
                int glasses = int.Parse(Console.ReadLine());

                databaseManager.InsertRecord(new DrinkWater
                {
                    Date = date,
                    Quantity = glasses,
                });

                break;
            case 3:
                records = databaseManager.GetDrinkWaterLog();
                foreach (DrinkWater record in records)
                    Console.WriteLine(record);
                Console.WriteLine("Type record's id.");
                int id = int.Parse(Console.ReadLine());

                break;


        }
    }
}