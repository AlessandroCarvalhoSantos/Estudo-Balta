namespace Desafio.View;

public static class CategoryView
{

    public static int MenuView()
    {
        int opcao;
        do
        {
            Console.Clear();
            PrintCategoryMenu();
            int.TryParse(Console.ReadLine(), out opcao);

        }while(opcao < 1 || opcao > 6);

        return opcao;
    }
    private static void PrintCategoryMenu()
    {
        Console.Clear();

        Menu.PrintHeader("MENU DE CATEGORIAS");

        Console.WriteLine("1 - Cadastrar");
        Console.WriteLine("2 - Listar");
        Console.WriteLine("3 - Buscar");
        Console.WriteLine("4 - Atualizar");
        Console.WriteLine("5 - Deletar");
        Console.WriteLine("6 - Sair");
        Console.Write("Opção: ");
    }

}