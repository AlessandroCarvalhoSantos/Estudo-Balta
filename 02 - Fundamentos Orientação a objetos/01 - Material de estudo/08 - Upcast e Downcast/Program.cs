namespace UpcastDownCast;


public class Program
{
    static void Main(string[] args)
    {
        //upcast
        var pessoa = new Pessoa();

        pessoa = new PessoaFisica();
        pessoa = new PessoaJuridica();

        Console.WriteLine(pessoa.ToString());

        //downcast
        var pessoaD = new Pessoa();
        var pessoaFisica =  new PessoaFisica();
        var pessoaJuridica =  new PessoaJuridica(); 

        pessoaFisica = (PessoaFisica)pessoaD;
        pessoaJuridica = (PessoaJuridica)pessoaD;
    }
}

public class Pessoa
{
    public string Nome { get; set; }
}

public class PessoaFisica : Pessoa
{
    public string CPF { get; set; }
}

public class PessoaJuridica : Pessoa
{
    public string CNPJ { get; set; }

}


