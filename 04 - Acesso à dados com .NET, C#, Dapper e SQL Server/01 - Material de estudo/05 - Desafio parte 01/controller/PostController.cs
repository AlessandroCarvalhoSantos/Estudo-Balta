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

      }while(option != 9);
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
          case 8:
              var idAddTag = GetIdSearch();
              if(idAddTag > 0)
                  AddTag(idAddTag);
          break;
          
      }
  }
  public List<Post> ListModelWithAssociados(int id = 0)
  {
      return new PostRepository(_connection).GetAllWithAssociados(id);
  }
  public void AddTag(int idAddTag)
  {
    var postTag = new PostTag();
    postTag.PostId = idAddTag;
    postTag.TagId = new PostController(_connection).GetIdSearch();
    new PostTagRepository(_connection).Create(postTag);
      
    Console.Write("Tag associada a um post: ");
    Console.Write("Digite qualquer tecla para continuar: ");
    Console.ReadLine();
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

      Console.Write("Título: ");
      post.Title = Console.ReadLine();
    
      Console.Write("Sumário: ");
      post.Summary = Console.ReadLine();
        
      Console.Write("Conteúdo: ");
      post.Body = Console.ReadLine();

      Console.Write("Slug: ");
      post.Slug = Console.ReadLine();

      post.CreateDate =  DateTime.Now;
      post.LastUpdateDate = DateTime.Now;
      return post;

  }
}