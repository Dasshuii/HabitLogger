using HabitLogger.Data;
using HabitLogger.Models;
using HabitLogger.Util;

namespace HabitLogger
{
    internal class DrinkingManager
    {
        public static void ShowDrinkingLog()
        {
            List<DrinkWater> records = DatabaseManager.GetDrinkWaterLog();
            foreach (DrinkWater record in records)
                Console.WriteLine(record);
        }
        public static DrinkWater CreateRecord()
        {
            string format = "dd-mm-yy";
            DateTime date = Input.GetDateInput($"Please insert date: (Format: {format}). Type 1 to Today's Date.", format);
            int quantity = Input.GetIntegerInput("Please insert the number of glasses or other measure of your choice.");
            return new DrinkWater { Date = date, Quantity = quantity };
        }

        public static void DeleteRecord()
        {
            int id = SelectRecord();
            DatabaseManager.DeleteRecord(id);
            Console.WriteLine("Record deleted successfully.");
        }

        public static void UpdateRecord()
        {

            int id = SelectRecord();
            DrinkWater updateRecord = CreateRecord();
            DatabaseManager.UpdateRecord(id, updateRecord.Date, updateRecord.Quantity);
        }

        private static int SelectRecord()
        {
            ShowDrinkingLog();
            return Input.GetIntegerInput("Type record's id");
        }
    }
}
