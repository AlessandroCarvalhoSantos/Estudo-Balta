namespace Pagamento;

public class PagamentoCartao : Pagamento
{
    public int NumeroCartao { get; set; }

    
    public override void Pagar(){
        Console.WriteLine(base.Vencimento);
        Console.WriteLine("Pagamento com Cartão");
    }

    public override string ToString()
    {
        return Vencimento.ToString("Pagamento no cartão: dd/mm/yyyy");
    }

    private bool VerificarCartao(string numero)
    {
        return true;
    }
}

