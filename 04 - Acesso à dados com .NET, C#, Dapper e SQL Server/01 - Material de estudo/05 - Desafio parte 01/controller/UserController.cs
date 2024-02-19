using Desafio.Model;
using Desafio.View;
using Desafio.Repository;
using Microsoft.Data.SqlClient;

namespace Desafio.Controller;

public class UserController : BaseController<User>
{
  public UserController(SqlConnection connection) : base(connection)
  {
   
  }
  protected override void PrintMenu() => Menu.PrintHeader("MENU DE USUÁRIOS");

  public void ExecuteMenuUser()
  {
      int option;
      do
      {
          Console.Clear();
          option = UserView.MenuView();
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
              var modelsWithRoles = ListModelWithRoles();
              UserView.PrintListUserWithRoles(modelsWithRoles);
          break;
          case 4:
              var id = GetIdSearch();
              if(id > 0)
                  SearchModel(id);
          break;
          case 5:
            var idRole = GetIdSearch();
            if (idRole > 0)
              UserView.PrintListUserWithRoles(ListModelWithRoles(idRole));
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
              var idAddRole = GetIdSearch();
              if(idAddRole > 0)
                  AddRole(idAddRole);
          break;
          
      }
  }

  public List<User> ListModelWithRoles(int id = 0)
  {
      return new UserRepository(_connection).GetAllWithRoles(id);
  }

  public void AddRole(int idAddRole)
  {
      Console.Write("Adicionando role");
  }

  public override User GetDataInfoModel()
  {
      var user = new User();
      Console.Write("Nome do user: ");
      user.Name = Console.ReadLine();

      Console.Write("Digite o email: ");
      user.Email = Console.ReadLine();

      Console.Write("Digite a senha: ");
      user.PasswordHash = Console.ReadLine();

      Console.Write("Digite a Bio: ");
      user.Bio = Console.ReadLine();

      Console.Write("Digite a url da imagem: ");
      user.Image = Console.ReadLine();

      Console.Write("Digite o slug: ");
      user.Slug = Console.ReadLine();

      return user;
  }
}