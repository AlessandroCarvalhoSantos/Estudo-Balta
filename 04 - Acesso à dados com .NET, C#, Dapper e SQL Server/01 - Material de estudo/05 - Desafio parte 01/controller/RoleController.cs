using Desafio.Model;
using Desafio.View;
using Microsoft.Data.SqlClient;
using Desafio.Repository;

namespace Desafio.Controller;

public class RoleController : BaseController<Role>
{
  public RoleController(SqlConnection connection) : base(connection)
  {
   
  }
  protected override void PrintMenu() => Menu.PrintHeader("MENU DE ROLE");


  public void ExecuteMenuRole()
  {
      int option;
      do
      {
          Console.Clear();
          option = RoleView.MenuView();
          var controller = new RoleController(_connection);
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
              var modelsWithUsers = ListModelWithUsers();
              RoleView.PrintListRolesWithUsers(modelsWithUsers);
          break;
          case 4:
              var id = GetIdSearch();
              if(id > 0)
                  SearchModel(id);
          break;
          case 5:
               var idRole = GetIdSearch();
               if(idRole > 0)
                   RoleView.PrintListRolesWithUsers(SearchRoleWithUser(idRole));
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

  public List<Role> ListModelWithUsers()
  {
      return new RoleRepository(_connection).GetAllWithUsers();
  }

  public List<Role> SearchRoleWithUser(int id)
  {
      return new RoleRepository(_connection).GetRoleWithUser(id);
  }


  public override Role GetDataInfoModel()
  {
      var role = new Role();
      Console.Write("Nome da role: ");
      role.Name = Console.ReadLine();

      Console.Write("Digite o Slug: ");
      role.Slug = Console.ReadLine();

      return role;
  }

 
}