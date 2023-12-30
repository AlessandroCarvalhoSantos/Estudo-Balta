using Pagamento;

namespace ClasseObjeto;

internal class Program
{
    static void Main(string[] args)
    {
        var pagamentoBoleto = new PagamentoBoleto();
        pagamentoBoleto.Vencimento = DateTime.Now;
        pagamentoBoleto.NumeroBoleto = 115252;

        var pagamentoCartao = new PagamentoCartao();
        pagamentoCartao.Vencimento = DateTime.Now;
        pagamentoCartao.NumeroCartao = 115252;
    }
}