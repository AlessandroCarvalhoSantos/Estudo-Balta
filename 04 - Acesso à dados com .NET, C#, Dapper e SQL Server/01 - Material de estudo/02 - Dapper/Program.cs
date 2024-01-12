namespace AccessDataBalta;

using AccessDataBalta.Model;
using Dapper;
using Microsoft.Data.SqlClient;

public class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        const string connectionString = "Server=localhost,1433;Database=balta;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True";

        //Usando query
        using (var connection = new SqlConnection(connectionString))
        {
            var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");

            foreach (var item in categories)
            {
                Console.WriteLine($"{item.Id} - {item.Title}");
            }
        }

        //Exemplificando o alias
        using (var connection = new SqlConnection(connectionString))
        {
            var categories = connection.Query<Categoria>("SELECT [Id] AS [Codigo], [Title] AS [Titulo] FROM [Category]");

            foreach (var item in categories)
            {
                Console.WriteLine($"{item.Codigo} - {item.Titulo}");
            }
        }


        //Exemplos de isntruções SQL
        using (var connection = new SqlConnection(connectionString))
        {
            UpdateCategory(connection);
            ListCategories(connection);
            //CreateCategory(connection);
        }


    }

    //Exemplificando o select
    static void ListCategories(SqlConnection sqlConnection)
    {

        var categories = sqlConnection.Query<Categoria>("SELECT [Id] AS [Codigo], [Title] AS [Titulo] FROM [Category]");

        foreach (var item in categories)
        {
            Console.WriteLine($"{item.Codigo} - {item.Titulo}");
        }   
    }

    //Exemplificando insert
    static void CreateCategory(SqlConnection sqlConnection)
    {

        var category = new Category();
        category.Id = Guid.NewGuid();
        category.Title = "Amazon Aws";
        category.Url = "amazon";
        category.Description = "Categoria destinada a serviços do AWS";
        category.Order = 8;
        category.Summary = "AWS Cloud";
        category.Featured = false;

        var insertSql = @"INSERT INTO [Category] VALUES (@Id, @Title, @Url, @Summary, @Order, @Description, @Featured)";

        var rows = sqlConnection.Execute(insertSql, category);

        Console.WriteLine($"{rows} linhas inseridas");
    }

       //Exemplificando insert
    static void UpdateCategory(SqlConnection sqlConnection)
    {

        var updateSql = @"UDPATE [Category] SET [Title] = @Title WHERE [Id] = @id";

        var rows = sqlConnection.Execute(updateSql, new {
            id = new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4"),
            title = "Frontend 2021"
        });

        Console.WriteLine($"{rows} registros inseridas");
    }



}
