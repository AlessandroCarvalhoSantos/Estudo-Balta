namespace Listas;


public class Program
{
    static void Main(string[] args)
    {
        // var payments = new List<Payment>();

        // IEnumerable<Payment> paymentsEnumerable =  new List<Payment>();
        // ICollection<Payment> paymentsCollection =  new List<Payment>();


        List<Payment> payments = new List<Payment>();

        payments.Add(new Payment(1));
        payments.Add(new Payment(2));
        payments.Add(new Payment(3));
        payments.Add(new Payment(4));
        payments.Add(new Payment(5));

        // foreach(var item in payments)
        // {
        //     Console.WriteLine(item.Id);
        // }

        var paidPayments = new List<Payment>();
        paidPayments.AddRange(payments);

        var paymentWhere = payments.Where(e=> e.Id == 3);
        var paymentFirst = payments.First(e=> e.Id == 3);
        var paymentFind = payments.Find(e=> e.Id == 3);

        payments.Remove(paymentFirst);

        payments.Any(e=>e.Id ==3);

        foreach(var item in payments.Skip(1))
        {
            Console.WriteLine(item.Id);
        }

        Console.WriteLine("-----------------------------------");

        foreach(var item in payments.Take(3))
        {
            Console.WriteLine(item.Id);
        }
    }
}

public class Payment
{
    public Payment(int id)
    {
        Id = id;
    }
    public int Id { get; set; }
}
