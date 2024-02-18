using System.Diagnostics;
using Dapper;
using Dapper.Contrib.Extensions;
using Desafio.Controller;
using Desafio.Model;
using Desafio.Repository;
using Desafio.View;
using Microsoft.Data.SqlClient;

namespace Desafio;


public class Program
{
    private const string CONNECTION_STRING = "Server=localhost,1433;Database=Brog;User ID = sa; Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True";
    static void Main(string[] args)
    {
        var connection = new SqlConnection(CONNECTION_STRING);
        connection.Open();
 

        int opcao;

        do
        {
            Console.Clear();
            opcao = Menu.MainView();

            switch (opcao)
            {
                case 1:
                    var categoryController = new CategoryController(connection);
                    categoryController.ExecuteMenuCategory();
                break;

                case 2:
                    var roleController = new RoleController(connection);
                    roleController.ExecuteMenuRole();
                break;

                case 3:
                    var tagController = new TagController(connection);
                    tagController.ExecuteMenuTag();
                break;

                case 4:
                    var userController = new UserController(connection);
                    userController.ExecuteMenuUser();
                break;

                case 5:
                    var postController = new PostController(connection);
                    postController.ExecuteMenuPost();
                break;
            }

        }while(opcao != 6);
        
        connection.Close();
    }
}
