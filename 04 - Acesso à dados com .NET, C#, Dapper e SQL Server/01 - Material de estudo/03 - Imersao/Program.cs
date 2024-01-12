using Dapper;
using Imersao.Model;
using Microsoft.Data.SqlClient;

namespace Imersao;


public class Program
{
    static void Main(string[] args)
    {

        var connectionString = "Server=localhost,1433;Database=balta;User ID = sa; Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True";
        using (var sqlConnection = new SqlConnection(connectionString))
        {
            InsertCategory(sqlConnection);
            UpdateCategory(sqlConnection);
            DeleteCategory(sqlConnection);
            ListCategories(sqlConnection);

        }
    }

    static void ListCategories(SqlConnection sqlConnection)
    {
        var selectQuery = "SELECT *  FROM [Category]";
        var categories = sqlConnection.Query<Category>(selectQuery);

        foreach(var item in categories)
        {
            Console.WriteLine($"{item.Id} - {item.Title} - {item.Url} - {item.Summary} - {item.Description} - {item.Order} - {item.Featured}");
        }
    }

    static void InsertCategory(SqlConnection sqlConnection)
    {
        var category = new Category();
        category.Id = Guid.NewGuid();
        category.Summary = "Azure";
        category.Title = "Curso de Azure";
        category.Featured = false;
        category.Order = 1;
        category.Description = "Curso de azure 2024 completo";
        category.Url = "www.azure.com";


        var insertQuery = "INSERT INTO [Category] VALUES(@Id, @Title, @Url, @Summary, @Order, @Description, @Featured)";
        var rows = sqlConnection.Execute(insertQuery, category);
        Console.WriteLine(rows);
    }   

    static void UpdateCategory(SqlConnection sqlConnection)
    {

        var updateQuery = "UPDATE [Category] SET [Title] = @Title WHERE [Id] = @Id";
        var rows = sqlConnection.Execute(updateQuery, new {Id = "4d8516ed-faf6-4c3a-a92b-57953fc96506", Title = "Curso de Azure atualizado 2024" });
        Console.WriteLine($"{rows} atualizados");
    }

    static void DeleteCategory(SqlConnection sqlConnection)
    {
        var updateQuery = "DELETE FROM [Category] WHERE [Id] = @Id";
        var rows = sqlConnection.Execute(updateQuery, new {Id = "a02dbce9-83c2-4d6f-9bc0-c3c6058ad881" });
        Console.WriteLine($"{rows} Deletadas");
    }
}