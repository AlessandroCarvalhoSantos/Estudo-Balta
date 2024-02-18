using Desafio.Model;

namespace Desafio.View;

public static class TagView
{
    public static int MenuView()
    {
        int opcao;
        do
        {
            Console.Clear();
            PrintTagMenu();
            int.TryParse(Console.ReadLine(), out opcao);

        }while(opcao < 1 || opcao > 8);

        return opcao;
    }
    private static void PrintTagMenu()
    {
        Console.Clear();

        Menu.PrintHeader("MENU DE TAGS");

        Console.WriteLine("1 - Cadastrar");
        Console.WriteLine("2 - Listar");
        Console.WriteLine("3 - Listar tags e seus POST");
        Console.WriteLine("4 - Buscar");
        Console.WriteLine("5 - Buscar tag e seus POST");
        Console.WriteLine("6 - Atualizar");
        Console.WriteLine("7 - Deletar");
        Console.WriteLine("8 - sair");
        Console.Write("Opção: ");
    } 

    public static void PrintListTagsWithPost(List<Tag> modelList)
    {
      Console.Clear();
      Menu.PrintHeader("MENU DE ROLES");

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