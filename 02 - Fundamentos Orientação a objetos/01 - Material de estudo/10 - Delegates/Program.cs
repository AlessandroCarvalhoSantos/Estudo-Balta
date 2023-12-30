namespace Delegates;


public class Program
{
    static void RealizarPagamento(double valor)
    {
        Console.WriteLine($"Pago o valor de {valor}");
    } 

    static void Main(string[] args)
    {
        var pagar = new Pagamento.Pagar(RealizarPagamento);
    }
}


public class Pagamento
{
    public delegate void Pagar(double valor);
    
}