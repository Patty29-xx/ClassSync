using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

public class DBHelper
{
    private static string dbPath = Path.Combine(Application.StartupPath, "Database", "classsync.db");

    private static string connectionString = $"Data Source={dbPath};Version=3;";

    public static SQLiteConnection GetConnection()
    {
        Console.WriteLine("DB Path: " + dbPath);  // For debugging: shows full path in Output window
        SQLiteConnection conn = new SQLiteConnection(connectionString);
        conn.Open();
        return conn;
    }
}
