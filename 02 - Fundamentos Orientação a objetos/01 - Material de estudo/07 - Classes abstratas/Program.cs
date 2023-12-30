namespace ClasseAbstrata;


public class Program
{
    static void Main(string[] args)
    {

    }
}

public class PagamentoCartaoCredito : Pagamento
{
   public override void Pagar()
   {
        base.Pagar();
   }
}

public class PagamentoBoleto : Pagamento
{
   public override void Pagar()
   {
        base.Pagar();
   }
}

public class PagamentoApplePay : Pagamento
{
   public override void Pagar()
   {
        base.Pagar();
   }
}


public abstract class Pagamento : IPagamento
{
    public DateTime Vencimento { get; set; }

    public virtual void Pagar()
    {
     
    }
}



public interface IPagamento
{
    DateTime Vencimento {get; set;}

    void Pagar();
}