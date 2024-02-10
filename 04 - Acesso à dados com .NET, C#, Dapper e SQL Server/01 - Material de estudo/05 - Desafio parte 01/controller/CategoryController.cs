using Desafio.Model;
using Desafio.View;
using Microsoft.Data.SqlClient;

namespace Desafio.Controller;

public class CategoryController : BaseController<Category>
{
  public CategoryController(SqlConnection connection) : base(connection)
  {
   
  }
  protected override void PrintMenu() => Menu.PrintHeader("MENU DE CATEGORIA");


  public void ExecuteMenuCategory()
  {
      int option;
      do
      {
          Console.Clear();
          option = CategoryView.MenuView();
          var controller = new CategoryController(_connection);
          controller.SwitchOption(option);

      }while(option != 6);
  }

  public override Category GetDataInfoModel()
  {
      var category = new Category();
      Console.Write("Nome da categoria: ");
      category.Name = Console.ReadLine();

      Console.Write("Digite o slug: ");
      category.Slug = Console.ReadLine();

      return category;
  }
}