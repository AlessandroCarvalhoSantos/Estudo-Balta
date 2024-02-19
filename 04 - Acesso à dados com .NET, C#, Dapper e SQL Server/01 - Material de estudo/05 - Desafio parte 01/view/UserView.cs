using Desafio.Model;

namespace Desafio.View;

public static class UserView
{
    public static int MenuView()
    {
        int opcao;
        do
        {
            Console.Clear();
            PrintUserMenu();
            int.TryParse(Console.ReadLine(), out opcao);

        }while(opcao < 1 || opcao > 9);

        return opcao;
    }
    private static void PrintUserMenu()
    {
        Console.Clear();

        Menu.PrintHeader("MENU DE USERS");

        Console.WriteLine("1 - Cadastrar");
        Console.WriteLine("2 - Listar");
        Console.WriteLine("3 - Listar Users e seus Roles");
        Console.WriteLine("4 - Buscar");
        Console.WriteLine("5 - Buscar Users e seus Roles");
        Console.WriteLine("6 - Atualizar");
        Console.WriteLine("7 - Deletar");
        Console.WriteLine("8 - Adicionar roles");
        Console.WriteLine("9 - sair");
        Console.Write("Opção: ");
    } 

    public static void PrintListUserWithRoles(List<User> modelList)
    {
      Console.Clear();
      Menu.PrintHeader("MENU DE USUARIOS");

      foreach (var model in modelList)
      {
        Console.WriteLine(model.ToString());
        if(model.Roles.Count() == 0)
        {
          Console.WriteLine("Nenhuma role associado a esse usuário");
        }
        else
        {
          Console.WriteLine($"---------------------------------------");
          Console.WriteLine($"-           Roles associados           -");
          Console.WriteLine($"---------------------------------------");

          foreach (var role in model.Roles)
          {
            Console.WriteLine(role.ToString());
            Console.WriteLine($"---------------------------------------");
          }
        }

        Console.WriteLine($"---------------------------------------");
      }

      if(modelList.Count() == 0)
        Console.WriteLine("Nenhuma usuário encontrada!");

      Console.Write("Digite qualquer tecla para continuar: ");
      Console.ReadLine();
    }
}