namespace ClasseSealed;


public class Program
{
    static void Main(string[] args)
    {

    }
}


//Classe selada que não permitida herança
public sealed class Pagamento{
    public int Idade { get; set; }
}