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

        }while(opcao < 1 || opcao > 8);

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
        Console.WriteLine("8 - sair");
        Console.Write("Opção: ");
    } 

    public static void PrintListTagsWithPost(List<Tag> modelList)
    {
      Console.Clear();
      Menu.PrintHeader("MENU DE ROLES");

      Menu.PrintSubHeader("TAGS");

      Console.WriteLine($"---------------------------------------");
      Console.WriteLine($"-                 TAGS                -");
      Console.WriteLine($"---------------------------------------");

      foreach (var model in modelList)
      {
        Console.WriteLine(model.ToString());
        if(model.Posts.Count() == 0)
        {
          Console.WriteLine("Nenhum post associado a essa tag");
        }
        else
        {
          Console.WriteLine($"---------------------------------------");
          Console.WriteLine($"-           POST associados           -");
          Console.WriteLine($"---------------------------------------");

          foreach (var user in model.Posts)
          {
            Console.WriteLine(user.ToString());
            Console.WriteLine($"---------------------------------------");
          }
        }

        Console.WriteLine($"---------------------------------------");
      }

      if(modelList.Count() == 0)
        Console.WriteLine("Nenhuma tag encontrada!");

      Console.Write("Digite qualquer tecla para continuar: ");
      Console.ReadLine();
    }
}