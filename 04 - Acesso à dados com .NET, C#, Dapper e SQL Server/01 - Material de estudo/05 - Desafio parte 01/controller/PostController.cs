using Desafio.Model;
using Desafio.Repository;
using Desafio.View;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Desafio.Controller;

public class PostController : BaseController<Post>
{
  public PostController(SqlConnection connection) : base(connection)
  {
   
  }
  protected override void PrintMenu() => Menu.PrintHeader("MENU DE POST");

  public void ExecuteMenuPost()
  {
      int option;
      do
      {
          Console.Clear();
          option = PostView.MenuView();
          var controller = new PostController(_connection);
          controller.SwitchOption(option);

      }while(option != 8);
  }

  public override void SwitchOption(int opcao)
  {
      switch (opcao)
      {
          case 1:
              var model = GetModel();
              if(model is not null)
                  CreateModel(model);
          break;
          case 2:
              var models = ListModel();
              PrintListModel(models);
          break;
          case 3:
            var modelsWithAssociados = ListModelWithAssociados();
            PostView.PrintListPost(modelsWithAssociados);
          break;
          case 4:
              var id = GetIdSearch();
              if(id > 0)
                  SearchModel(id);
          break;
          case 5:
            var idPost = GetIdSearch();
            if (idPost > 0)
              PostView.PrintListPost(ListModelWithAssociados(idPost));
           break;
          case 6:
              var updateModel = GetUpdateModel();
              if(updateModel is not null)
                  UpdateModel(updateModel);
          break;
          case 7:
              var idModelUpdate = GetIdSearch();
              if(idModelUpdate > 0)
                  DeleteModel(idModelUpdate);
          break;
          
      }
  }
  public List<Post> ListModelWithAssociados(int id = 0)
  {
      return new PostRepository(_connection).GetAllWithAssociados(id);
  }


  public override Post GetDataInfoModel()
  {
      var post = new Post();
      Console.Write("Author(ID): ");
      int.TryParse(Console.ReadLine(),out var authorId);
      post.AuthorId = authorId;

      Console.Write("Categoria(ID): ");
      int.TryParse(Console.ReadLine(),out var categoriaId);
      post.CategoryId = categoriaId;

      Console.Write("T�tulo: ");
      post.Title = Console.ReadLine();
    
      Console.Write("Sum�rio: ");
      post.Summary = Console.ReadLine();
        
      Console.Write("Conte�do: ");
      post.Body = Console.ReadLine();

      Console.Write("Slug: ");
      post.Slug = Console.ReadLine();

      post.CreateDate =  DateTime.Now;
      post.LastUpdateDate = DateTime.Now;
      return post;

  }
}