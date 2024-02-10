using Desafio.Model;
using Desafio.View;
using Microsoft.Data.SqlClient;

namespace Desafio.Controller;

public class PostController : BaseController<Post>
{
  public PostController(SqlConnection connection) : base(connection)
  {
   
  }
  protected override void PrintMenu() => Menu.PrintHeader("MENU DE POST");

  public override Post GetDataInfoModel()
  {
      var post = new Post();
      Console.Write("Nome da tag: ");
      post.Title = Console.ReadLine();

      Console.Write("Digite o tag: ");
      post.Slug = Console.ReadLine();

      return post;
  }
}