namespace Desafio.View;

public static class Menu
{
    public static int MainView()
    {
        int opcao;
        do
        {
            Console.Clear();
            PrintMainMenu();
            int.TryParse(Console.ReadLine(), out opcao);

        }while(opcao < 1 || opcao > 6);

        return opcao;
    }
    private static void PrintMainMenu()
    {
        Console.Clear();

        PrintHeader("MENU DO BROG");

        Console.WriteLine("1 - Categorias");
        Console.WriteLine("2 - Roles");
        Console.WriteLine("3 - Tags");
        Console.WriteLine("4 - Usuários");
        Console.WriteLine("5 - Post");
        Console.WriteLine("6 - Sair");
        Console.Write("Opção: ");
        
    }

    public static int CategoryView()
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

        PrintHeader("MENU DE CATEGORIAS");

        Console.WriteLine("1 - Cadastrar");
        Console.WriteLine("2 - Listar");
        Console.WriteLine("3 - Buscar");
        Console.WriteLine("4 - Atualizar");
        Console.WriteLine("5 - Deletar");
        Console.WriteLine("6 - Sair");
        Console.Write("Opção: ");
    }

    public static int RoleView()
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

        PrintHeader("MENU DE ROLES");

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

    public static int TagView()
    {
        int opcao;
        do
        {
            Console.Clear();
            PrintTagMenu();
            int.TryParse(Console.ReadLine(), out opcao);

        }while(opcao < 1 || opcao > 6);

        return opcao;
    }
    private static void PrintTagMenu()
    {
        Console.Clear();

        PrintHeader("MENU DE TAGS");
        
        Console.WriteLine("1 - Cadastrar");
        Console.WriteLine("2 - Listar");
        Console.WriteLine("3 - Buscar");
        Console.WriteLine("4 - Atualizar");
        Console.WriteLine("5 - Deletar");
        Console.WriteLine("6 - sair");
        Console.Write("Opção: ");
    }


    public static void PrintHeader(string title){

        for (int i = 0; i < title.Length+35; i++)
            Console.Write("#");
 
        Console.Write($"\n##               {title}                ##\n");

        for (int i = 0; i < title.Length+35; i++)
            Console.Write("#");

        Console.WriteLine("\n");
    }

   public static void PrintSubHeader(string title){

        for (int i = 0; i < title.Length+30; i++)
            Console.Write("-");
 
        Console.Write($"\n-             {title}              -\n");

        for (int i = 0; i < title.Length+30; i++)
            Console.Write("-");

        Console.WriteLine("\n");
   }

}