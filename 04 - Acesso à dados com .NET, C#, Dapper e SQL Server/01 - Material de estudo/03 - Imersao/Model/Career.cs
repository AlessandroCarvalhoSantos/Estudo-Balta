namespace Imersao.Model;

public class Career
{
    public Career()
    {
        CareerItemList = new List<CareerItem>();
    }
    public Guid Id {get;set;}
    public string Title { get; set; }

    public List<CareerItem> CareerItemList { get; set; }
}
