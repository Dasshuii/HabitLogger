using HabitLogger.Models;
using Microsoft.Data.Sqlite;

namespace HabitLogger.Data
{
    internal class DatabaseManager {
        private static readonly string connectionString = @"Data Source=habit_logger.db";

        public static void CreateTables()
        {
            const string queryString = "CREATE TABLE IF NOT EXISTS drinking_water (" +
                "id INTEGER NOT NULL PRIMARY KEY," +
                "date TEXT NOT NULL," +
                "quantity INTEGER NOT NULL" +
                ");";

            using SqliteConnection conn = new(connectionString);
            conn.Open();
            SqliteCommand tableCmd = conn.CreateCommand();

            tableCmd.CommandText = queryString;
            tableCmd.ExecuteNonQuery();
            conn.Close();
        }

        public static List<DrinkWater> GetDrinkWaterLog()
        {
            List<DrinkWater> drinkingLog = [];

            using SqliteConnection conn = new(connectionString);
            SqliteCommand command = new("SELECT * FROM drinking_water;", conn);
            conn.Open();

            SqliteDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while(reader.Read())
                {
                    drinkingLog.Add(new DrinkWater
                    {
                        Id = reader.GetInt32(0),
                        Date = reader.GetDateTime(1),
                        Quantity = reader.GetInt32(2)
                    });
                }
            } else Console.WriteLine("No rows found");

            reader.Close();
            return drinkingLog;
        }

        public static void InsertRecord(DrinkWater record)
        {
            using SqliteConnection conn = new(connectionString);
            SqliteCommand command = new("INSERT INTO drinking_water (date, quantity) VALUES (@date, @quantity);", conn);
            command.Parameters.AddWithValue("@date", record.Date);
            command.Parameters.AddWithValue("@quantity", record.Quantity);
            conn.Open();

            command.ExecuteNonQuery();
            conn.Close();
        }

        public static void DeleteRecord(int id)
        {
            using SqliteConnection conn = new(connectionString);
            SqliteCommand command = new("DELETE FROM drinking_water WHERE id = @id", conn);
            command.Parameters.AddWithValue("@id", id);
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }

        public static void UpdateRecord(int id, DateTime date, int quantity) 
        {
            using SqliteConnection conn = new(connectionString);
            SqliteCommand command = new("UPDATE drinking_water SET date = @date, quantity = @quantity WHERE id = @id", conn);

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@date", date);
            command.Parameters.AddWithValue("@quantity", quantity);
            
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }
    }
}
