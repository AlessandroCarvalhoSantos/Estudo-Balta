namespace Pagamento;

public class PagamentoBoleto : Pagamento
{

    public PagamentoBoleto()
    {
        
    }
    public PagamentoBoleto(string numero): base(numero)
    {
        
    }
    public int NumeroBoleto { get; set; }

    public override void Pagar(){
        Console.WriteLine("Pagamento com boleto");
    }


}

