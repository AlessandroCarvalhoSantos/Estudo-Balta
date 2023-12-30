using PagamentoClass;

namespace ClassePartial;


public class Program
{
    static void Main(string[] args)
    {
        var pagamento = new Pagamento();
        pagamento.Vencimento = DateTime.Now;

        pagamento.Pagar();
    }
}