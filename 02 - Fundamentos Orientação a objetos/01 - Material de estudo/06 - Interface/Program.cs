namespace InferfaceAndClasses;


public class Program
{
    static void Main(string[] args)
    {
        
    }
}

public interface IPagamento
{
    DateTime Vencimento {get; set;}

    void Pagar();
    
}

public class Pagamento : IPagamento
{
    public DateTime Vencimento { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public void Pagar()
    {
        throw new NotImplementedException();
    }
}


