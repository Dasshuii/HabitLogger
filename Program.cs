using HabitLogger;
using SQLitePCL;

internal class Program
{
    private static void Main(string[] args)
    {
        Batteries.Init();
        DatabaseManager databaseManager = new DatabaseManager();
        databaseManager.CreateTables();
    }
}