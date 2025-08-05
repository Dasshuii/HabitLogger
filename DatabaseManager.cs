using Microsoft.Data.Sqlite;
using System.Data;


namespace HabitLogger
{
    internal class DatabaseManager {
        const string connectionString = @"Data Source=habit_logger.db";

        public void CreateTables()
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

        public List<DrinkWater> GetDrinkWaterLog()
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

        public void InsertRecord(DrinkWater record)
        {
            using SqliteConnection conn = new(connectionString);
            SqliteCommand command = new("INSERT INTO drinking_water (date, quantity) VALUES (@date, @quantity);", conn);
            command.Parameters.AddWithValue("@date", record.Date);
            command.Parameters.AddWithValue("@quantity", record.Quantity);
            conn.Open();

            command.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteRecord(int id)
        {
            using SqliteConnection conn = new(connectionString);
            SqliteCommand command = new
        }
    }
}
