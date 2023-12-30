namespace UsingAndDispose;

public class Program
{
    static void Main(string[] args)
    {
        using(var pagamento = new Pagamento())
        {
            pagamento.Pagar();
        }
    }
}


public class Pagamento : IDisposable
{
    public int Numero { get; set; }

    public Pagamento()
    {
        Console.WriteLine("Inicializando processamento");
    }

    public void Pagar()
    {
        Console.WriteLine("Realizando processamento");
    }

    public void Dispose()
    {
        Console.WriteLine("Finalizando processamento");
    }
    
}