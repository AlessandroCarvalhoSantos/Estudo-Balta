namespace ComparandoObjetos;


public class Program
{
    static void Main(string[] args)
    {
        var pessoaA = new Pessoa(1,"Alessandro");
        var pessoaB = new Pessoa(1,"Alessandro");

        Console.WriteLine(pessoaA == pessoaB);

        Console.WriteLine(pessoaA.Equals(pessoaB));
    }
}

public class Pessoa : IEquatable<Pessoa>
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public Pessoa(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }

    public bool Equals(Pessoa? pessoa)
    {
        return Id == pessoa.Id;
    }
}




