using ProjetoFinal.NotificationContext;
using ProjetoFinal.SharedContext;

namespace ProjetoFinal.SubscriptionContext;


public class Student : Base
{
    public Student()
    {
        Subscriptions = new List<Subscription>();
    }

    public string Name { get; set; }
    public string Email { get; set; }
    public User User { get; set; }

    public IList<Subscription> Subscriptions { get; set; }

    public void CreateSubscription(Subscription Subscription)
    {
        if(IsPremium)
        {
            AddNotification(new Notification("Premium", "O Aluno já tem uma assinatura ativa"));
            return;
        }

        Subscriptions.Add(Subscription);
    }

    public bool IsPremium => Subscriptions.Any(e=>!e.IsInactive);
}