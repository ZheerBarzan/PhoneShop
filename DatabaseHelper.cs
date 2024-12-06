using Microsoft.Data.SqlClient;
using System.Configuration;

public class DatabaseHelper
{
    // Connection string fetched from App.config
    private static string connectionString = ConfigurationManager.ConnectionStrings["PhoneShopDBConnectionString"].ConnectionString;

    // Method to get an open connection
    public static SqlConnection GetConnection()
    {
        return new SqlConnection(connectionString);
    }

    // Method to test the connection and print to the console
    public static bool TestConnection()
    {
        try
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open(); // Open the connection
                Console.WriteLine("Connection successful!"); // Output to console
                return connection.State == System.Data.ConnectionState.Open;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Connection failed: {ex.Message}"); // Output error message to console
            return false;
        }
    }
}
