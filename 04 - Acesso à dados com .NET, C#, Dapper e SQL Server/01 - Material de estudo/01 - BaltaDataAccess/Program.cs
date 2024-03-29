﻿namespace AccessDataBalta;

using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;

public class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        const string connectionString = "Server=localhost,1433;Database=balta;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True";

        // var connection = new SqlConnection();
        // connection.Open();
        // connection.Close();
        // connection.Dispose();


        using (var connection = new SqlConnection(connectionString))
        {
            Console.WriteLine("Conectado");
            connection.Open();


            using(var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT [Id],[Title] FROM [Category]";

                var reader = command.ExecuteReader();

                while(reader.Read()){
                    Console.WriteLine($"{reader.GetGuid(0)} - {reader.GetString(1)} ");
                }
            }
        }
    }
}
