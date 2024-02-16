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

  public void ExecuteMenuUser()
  {
      int option;
      do
      {
          Console.Clear();
          option = TagView.MenuView();
          var controller = new UserController(_connection);
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
              // var modelsWithPosts = ListModelWithPost();
              // TagView.PrintListTagsWithPost(modelsWithPosts);
          break;
          case 4:
              var id = GetIdSearch();
              if(id > 0)
                  SearchModel(id);
          break;
          case 5:
            // var idRole = GetIdSearch();
            // if (idRole > 0)
            //   TagView.PrintListTagsWithPost(SearchTagWithPost(idRole));
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


  public override User GetDataInfoModel()
  {
      var user = new User();
      Console.Write("Nome do user: ");
      user.Name = Console.ReadLine();

      Console.Write("Digite o Email: ");
      user.Slug = Console.ReadLine();

      Console.Write("Digite a senha: ");
      user.Slug = Console.ReadLine();


      return user;
  }
}