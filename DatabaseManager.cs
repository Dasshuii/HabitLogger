using Microsoft.Data.Sqlite;


namespace HabitLogger
{
    internal class DatabaseManager {
        const string connectionString = @"Data Source=C:\Users\dassh\source\repos\HabitLogger\HabitLogger\habit_logger.db";

        public void CreateTables()
        {
            const string queryString = "CREATE TABLE IF NOT EXISTS drinking_water (" +
                "id INTEGER NOT NULL PRIMARY KEY," +
                "date TEXT NOT NULL," +
                "quantity INTEGER NOT NULL" +
                ");";

            using (SqliteConnection conn = new(connectionString))
            {
                conn.Open();
                var tableCmd = conn.CreateCommand();

                tableCmd.CommandText = queryString;
                tableCmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
