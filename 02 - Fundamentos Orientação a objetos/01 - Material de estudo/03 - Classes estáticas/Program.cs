namespace ClassesEstaticas;


public class Program
{
    static void Main(string[] args)
    {
        Utils.DiaAtual();
    }
}


public static class Utils
{
    public static DateTime Hoje { get; set; } = DateTime.Now;

    public static void DiaAtual(){
        Console.WriteLine(Hoje);
    }
}