using Desafio.Model;
using Desafio.Repository;
using Desafio.View;
using Microsoft.Data.SqlClient;

namespace Desafio.Controller;

public class TagController : BaseController<Tag>
{
  public TagController(SqlConnection connection) : base(connection)
  {
   
  }
  protected override void PrintMenu() => Menu.PrintHeader("MENU DE TAG");

  public void ExecuteMenuTag()
  {
      int option;
      do
      {
          Console.Clear();
          option = TagView.MenuView();
          var controller = new TagController(_connection);
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
              var modelsWithPosts = ListModelWithPost();
              TagView.PrintListTagsWithPost(modelsWithPosts);
          break;
          case 4:
              var id = GetIdSearch();
              if(id > 0)
                  SearchModel(id);
          break;
          case 5:
            var idRole = GetIdSearch();
            if (idRole > 0)
              TagView.PrintListTagsWithPost(ListModelWithPost(idRole));
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

  public List<Tag> ListModelWithPost(int id = 0)
  {
      return new TagRepository(_connection).GetAllWithPost(id);
  }


  public override Tag GetDataInfoModel()
  {
      var tag = new Tag();
      Console.Write("Nome da tag: ");
      tag.Name = Console.ReadLine();

      Console.Write("Digite o SLUG: ");
      tag.Slug = Console.ReadLine();

      return tag;
  }
}