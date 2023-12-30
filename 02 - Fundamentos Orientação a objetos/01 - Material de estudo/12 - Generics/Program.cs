namespace ClassesGenericas;


public class Program
{
    static void Main(string args)
    {
        var context = new DataContext<IPerson, Payment, Subscription>();

        var pessoa = new Person();
        var payment = new Payment();
        var subscription = new Subscription();
        context.Save(pessoa);
        context.Save(payment);
        context.Save(subscription);
    }
}

public class DataContext<P, PA, S> where P : IPerson where PA : Payment where S: Subscription
{

    public void Save(P entidade)
    {
    }

    public void Save(PA entidade)
    {
    }

    public void Save(S entidade)
    {
    }
}


public interface IPerson
{
    
}

public class Person: IPerson{
}

public class Payment{

}

public class Subscription{

}

