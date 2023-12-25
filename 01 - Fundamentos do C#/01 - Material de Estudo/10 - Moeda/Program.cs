using System.Globalization;

public class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        decimal valor1 = 11152.12M;
        double valor2 = 11.5D;
        float valor3 = 11.5f;

        var cultura = new CultureInfo("pt-br");

        Console.WriteLine(valor1.ToString(cultura));
        Console.WriteLine(valor1.ToString(CultureInfo.CreateSpecificCulture("pt-br")));

        Console.WriteLine(valor1.ToString("g", cultura));
        Console.WriteLine(valor1.ToString("G", cultura));

        Console.WriteLine(valor1.ToString("c", cultura));
        Console.WriteLine(valor1.ToString("C", cultura));

        
        Console.WriteLine(valor1.ToString("E04", cultura));
        Console.WriteLine(valor1.ToString("e03", cultura));

        Console.WriteLine(valor1.ToString("p", cultura));
        Console.WriteLine(valor1.ToString("P", cultura));

        
        Console.WriteLine(valor1.ToString("f", cultura));
        Console.WriteLine(valor1.ToString("F4", cultura));

        Console.WriteLine(valor1.ToString("n", cultura));
        Console.WriteLine(valor1.ToString("N", cultura));

        Console.WriteLine(Math.Round(valor1));
        Console.WriteLine(Math.Ceiling(valor1));
        Console.WriteLine(Math.Floor(valor1));
    }
}
