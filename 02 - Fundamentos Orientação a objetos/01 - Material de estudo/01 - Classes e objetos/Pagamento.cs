namespace Pagamento;

public class Pagamento
{
    public Pagamento()
    {
        Console.WriteLine("Inicializando pagamento");
    }

    public Pagamento(string numero)
    {
        Console.WriteLine("Setando número e Inicializando pagamento");
    }

    public DateTime Vencimento { get; set; }

    protected bool Valido = true;

    public virtual void Pagar(){

    }

    public virtual void Pagar(string numero, bool possui = false){

    }


}

