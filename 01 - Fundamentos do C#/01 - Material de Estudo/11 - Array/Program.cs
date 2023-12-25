
using System.Security.Claims;

public class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        int[] array = new int[5]{1,2,3,4,5};
        Console.WriteLine(array[0]);

        Teste[] arrayTeste = new Teste[2]{new Teste(), new Teste()};

        arrayTeste[0].id = 5;


        var clone = array.Clone();

         var tamanho = array.Length;

        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine(array[i]);
        }

        foreach (var item in array)
        {
            Console.WriteLine(item);
        }

        Funcionario[] funcionarios = new Funcionario[2];


        funcionarios[0]= new Funcionario();
        funcionarios[1]= new Funcionario();

    
        foreach(var item in funcionarios)
        {
            item.Idade = 5;
            item.Nome = "sadas";
            Console.WriteLine(item.Idade);
            Console.WriteLine(item.Nome);
        }


        var a = new int[2]{1,2};
        var b = a;

        a[0] = 10;
        Console.WriteLine(b[0]); // 10

        int[] sourceArray = {1, 2, 3, 4, 5};
        int[] destinationArray = new int[10]; // Supondo que temos um array de destino maior

        // Copiando o array
        sourceArray.CopyTo(destinationArray, 0);


    }

    struct Teste()
    {
        public int id;
    }

    class Funcionario()
    {
        public int Idade {get;set;}=0;
        public string Nome{get;set;} = "uuy";
    }

}
