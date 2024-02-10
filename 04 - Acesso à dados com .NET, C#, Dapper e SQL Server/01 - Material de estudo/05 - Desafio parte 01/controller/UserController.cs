using Desafio.Model;
using Desafio.View;
using Microsoft.Data.SqlClient;

namespace Desafio.Controller;

public class UserController : BaseController<User>
{
  public UserController(SqlConnection connection) : base(connection)
  {
   
  }
  protected override void PrintMenu() => Menu.PrintHeader("MENU DE POST");

  public override User GetDataInfoModel()
  {
      var user = new User();
      Console.Write("Nome do user: ");
      user.Name = Console.ReadLine();

      Console.Write("Digite o user: ");
      user.Slug = Console.ReadLine();

      return user;
  }
}