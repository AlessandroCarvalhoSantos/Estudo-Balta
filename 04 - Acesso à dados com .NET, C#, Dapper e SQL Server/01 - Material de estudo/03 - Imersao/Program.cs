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
            //InsertCategory(sqlConnection);
            //InsertManyCategory(sqlConnection);

            //UpdateCategory(sqlConnection);
            //DeleteCategory(sqlConnection);
            //ExecuteProcedure(sqlConnection);
            //ListCategories(sqlConnection);
            //ExecuteReadProcedure(sqlConnection);
            //ExecuteScalar(sqlConnection);
            //ReadView(sqlConnection);
            //OneToOne(sqlConnection);
            //OneToMany(sqlConnection);
            //QueryMultiple(sqlConnection);
            //SelectIn(sqlConnection);
            //Like(sqlConnection, "api");
            Transaction(sqlConnection);
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

    static void InsertManyCategory(SqlConnection sqlConnection)
    {
        var category = new Category();
        category.Id = Guid.NewGuid();
        category.Summary = "Azure";
        category.Title = "Curso de Azure";
        category.Featured = false;
        category.Order = 1;
        category.Description = "Curso de azure 2024 completo";
        category.Url = "www.azure.com";

        var category2 = new Category();
        category2.Id = Guid.NewGuid();
        category2.Summary = "Nova categoria";
        category2.Title = "Nova categoria";
        category2.Featured = false;
        category2.Order = 1;
        category2.Description = "Nova categoria completo";
        category2.Url = "www.NovaCategoria.com";

        var insertQuery = "INSERT INTO [Category] VALUES(@Id, @Title, @Url, @Summary, @Order, @Description, @Featured)";
        var rows = sqlConnection.Execute(insertQuery, new []{category , category2});
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

    static void ExecuteProcedure(SqlConnection sqlConnection)
    {
        var sql = "[spDeleteStudent]";
        var param = new {StudentId = "a288a9b9-99ed-428d-be96-1643c727ccbc"};

        var rows= sqlConnection.Execute(sql, param, commandType: System.Data.CommandType.StoredProcedure);

        Console.WriteLine($"Linhas afetadas: {rows}");
    }

    static void ExecuteReadProcedure(SqlConnection sqlConnection)
    {
        var sql = "[spGetCourseByCategory]";
        var param = new {CategoryId = "b4c5af73-7e02-4ff7-951c-f69ee1729cac"};

        var courses = sqlConnection.Query(sql, param, commandType: System.Data.CommandType.StoredProcedure);

         foreach(var item in courses)
        {
            Console.WriteLine($"{item.Id} - {item.Title} - {item.Url} - {item.Summary} - {item.Description} - {item.Featured}");
        }
    }

    static void ExecuteScalar(SqlConnection sqlConnection)
    {
        var category = new Category();
        category.Summary = "Azure";
        category.Title = "Curso de Azure";
        category.Featured = false;
        category.Order = 1;
        category.Description = "Curso de azure 2024 completo";
        category.Url = "www.azure.com";

        var insertQuery = "INSERT INTO [Category] OUTPUT inserted.[Id] VALUES(NEWID(), @Title, @Url, @Summary, @Order, @Description, @Featured)";        
        var id = sqlConnection.ExecuteScalar<Guid>(insertQuery, category);
        Console.WriteLine($"A categoria inserida com o id = {id}");

    }

    static void ReadView(SqlConnection sqlConnection)
    {
        var sql = "SELECT * FROM [vwCourses]"; 

        var course = sqlConnection.Query(sql);

        foreach(var item in course)
        {
            Console.WriteLine($"{item.Id} - {item.Title} - {item.Url} - {item.Summary} - {item.Description} - {item.Order} - {item.Featured}");
        }
    }

    static void OneToOne(SqlConnection sqlConnection)
    {
        var sql = @"SELECT * FROM [CareerItem] 
                    INNER JOIN [Course] ON [CareerItem].[CourseId] = [Course].[Id]
                    INNER JOIN [Career] ON [CareerItem].[CareerId] = [Career].[Id]";

        var items = sqlConnection.Query<CareerItem,Course, Career,CareerItem>(sql,
            (careerItem, course, career)=>{
                careerItem.Course = course;
                careerItem.Career = career;
                return careerItem;
            }, splitOn: "Id");

        foreach (var item in items)
        {
            Console.WriteLine($"{item.Title} - Curso: {item.Course.Title} - Career: {item.Career.Title}");
        }
    }

    static void OneToMany(SqlConnection sqlConnection)
    {
        var sql = @"SELECT [Career].[Id], [Career].[Title], [CareerItem].[CareerId] AS [Id], [CareerItem].[Title] FROM [Career]
                    INNER JOIN [CareerItem] ON [CareerItem].[CareerId] = [Career].[Id]
                    ORDER BY [Career].[Title]";

        var careers = new List<Career>();

        var items = sqlConnection.Query<Career,CareerItem, Career>(sql,
            (career, careerItem)=>{

                var item = careers.Where(w=>w.Id == careerItem.Id).FirstOrDefault();
                if(item is not null)
                {
                    item.CareerItemList.Add(careerItem);
                }
                else
                {
                    careers.Add(career);
                    career.CareerItemList.Add(careerItem);

                }
          
                return career;
            }, splitOn: "Id");

        foreach (var career in careers)
        {
            Console.WriteLine($"Carreira: {career.Title}");
            foreach (var CareerItem in career.CareerItemList)
            {
                Console.WriteLine($" - Item: {CareerItem.Title}");
            }
        }
    }

    static void QueryMultiple(SqlConnection sqlConnection)
    {
        var sql = "SELECT * FROM [Course]; SELECT * FROM [Category]";

        using (var multi = sqlConnection.QueryMultiple(sql))
        {
            
            var courses = multi.Read<Course>();
            var categories = multi.Read<Category>();

            foreach (var course in courses)
            {
                Console.WriteLine($"Curso: {course.Title}");
            }

            foreach (var category in categories)
            {
                Console.WriteLine($"Categoria: {category.Title}");
            }
        }
    }
    
    static void SelectIn(SqlConnection sqlConnection)
    {
        var query = @"SELECT TOP 10 * FROM [Career] WHERE [Id] IN @Id";

        var items = sqlConnection.Query<Career>(query, new {
            id = new[]{
                "4327ac7e-963b-4893-9f31-9a3b28a4e72b",
                "01ae8a85-b4e8-4194-a0f1-1c6190af54cb"
            }
        });

        foreach (var item in items)
        {
           Console.WriteLine($"{item.Title}"); 
        }
    }

    static void Like(SqlConnection sqlConnection, string term)
    {
        var query = @"SELECT * FROM [Course] WHERE [Title] LIKE @Exp";
        var items = sqlConnection.Query<Course>(query, new {
            exp = $"%{term}%"
        });

        foreach (var item in items)
        {
           Console.WriteLine($"{item.Title}"); 
        }
    }

    static void Transaction(SqlConnection sqlConnection)
    {
        var category = new Category();
        category.Id = Guid.NewGuid();
        category.Summary = "Azure";
        category.Title = "Minha categoria";
        category.Featured = false;
        category.Order = 1;
        category.Description = "Curso de azure 2024 completo";
        category.Url = "www.azure.com";
         
        sqlConnection.Open();


        var insertQuery = "INSERT INTO [Category] VALUES(@Id, @Title, @Url, @Summary, @Order, @Description, @Featured)";
        using (var transaction = sqlConnection.BeginTransaction())
        {
            var rows = sqlConnection.Execute(insertQuery, category, transaction);
            Console.WriteLine(rows);

            //transaction.Commit();
            transaction.Rollback();
        }

    }   

}
