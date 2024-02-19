using Desafio.Model;

namespace Desafio.View;

public static class PostView
{
    public static int MenuView()
    {
        int opcao;
        do
        {
            Console.Clear();
            PrintPostMenu();
            int.TryParse(Console.ReadLine(), out opcao);

        }while(opcao < 1 || opcao > 9);

        return opcao;
    }
    private static void PrintPostMenu()
    {
        Console.Clear();

        Menu.PrintHeader("MENU DE POST");

        Console.WriteLine("1 - Cadastrar");
        Console.WriteLine("2 - Listar");
        Console.WriteLine("3 - Listar POST e seus associados");
        Console.WriteLine("4 - Buscar");
        Console.WriteLine("5 - Buscar POST e seus associados");
        Console.WriteLine("6 - Atualizar");
        Console.WriteLine("7 - Deletar");
        Console.WriteLine("8 - Adicionar tags");
        Console.WriteLine("9 - sair");
        Console.Write("Opção: ");
    } 

    public static void PrintListPost(List<Post> modelList)
    {
      Console.Clear();
      Menu.PrintHeader("MENU DE POST");

      foreach (var model in modelList)
      {
        Console.WriteLine(model.ToString());
        if (model.Tags.Count() == 0)
        {
          Console.WriteLine("Nenhuma tag associado a esse post");
        }
        else
        {
          Console.WriteLine($"---------------------------------------");
          Console.WriteLine($"-           Tags associados           -");
          Console.WriteLine($"---------------------------------------");

          foreach (var tag in model.Tags)
          {
            Console.WriteLine(tag.ToString());
            Console.WriteLine($"---------------------------------------");
          }
        }

        Console.WriteLine($"---------------------------------------");
      }

      if (modelList.Count() == 0)
        Console.WriteLine("Nenhum post encontrada!");

      Console.Write("Digite qualquer tecla para continuar: ");
      Console.ReadLine();
  }
}