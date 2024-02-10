using Desafio.Model;

namespace Desafio.View;

public static class RoleView
{
    public static int MenuView()
    {
        int opcao;
        do
        {
            Console.Clear();
            PrintRoleMenu();
            int.TryParse(Console.ReadLine(), out opcao);

        }while(opcao < 1 || opcao > 8);

        return opcao;
    }
    private static void PrintRoleMenu()
    {
        Console.Clear();

        Menu.PrintHeader("MENU DE ROLES");

        Console.WriteLine("1 - Cadastrar");
        Console.WriteLine("2 - Listar");
        Console.WriteLine("3 - Listar roles e seus usuários");
        Console.WriteLine("4 - Buscar");
        Console.WriteLine("5 - Buscar role e seus usuários");
        Console.WriteLine("6 - Atualizar");
        Console.WriteLine("7 - Deletar");
        Console.WriteLine("8 - sair");
        Console.Write("Opção: ");
    } 

    public static void PrintListRolesWithUsers(List<Role> modelList)
    {
      Console.Clear();
      Menu.PrintHeader("MENU DE ROLES");


      Console.WriteLine($"---------------------------------------");
      Console.WriteLine($"-                Roles                -");
      Console.WriteLine($"---------------------------------------");

      foreach (var model in modelList)
      {
        Console.WriteLine(model.ToString());
        if(model.Users.Count() == 0)
        {
          Console.WriteLine("Nenhum usuário associado a essa role");
        }
        else
        {
          Console.WriteLine($"---------------------------------------");
          Console.WriteLine($"-         Usuários associados         -");
          Console.WriteLine($"---------------------------------------");

          foreach (var user in model.Users)
          {
            Console.WriteLine(user.ToString());
            Console.WriteLine($"---------------------------------------");
          }
        }

        Console.WriteLine($"---------------------------------------");
      }

      if(modelList.Count() == 0)
        Console.WriteLine("Nenhuma role encontrada!");

      Console.Write("Digite qualquer tecla para continuar: ");
      Console.ReadLine();
    }
}