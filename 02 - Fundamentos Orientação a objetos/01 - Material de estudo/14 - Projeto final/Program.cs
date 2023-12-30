using ProjetoFinal.ContentContext;
using ProjetoFinal.SubscriptionContext;

namespace ProjetoFinal;


public class Program
{
    static void Main(string[] args)
    {
        var articles = new List<Article>();
        articles.Add(new Article("Artigo sobre OPP", "orientacao-objetos"));
        articles.Add(new Article("Artigo sobre C#", "csharp"));
        articles.Add(new Article("Artigo sobre .NET", "dotnet"));

        // foreach (var article in articles)
        // {
        //     Console.WriteLine(article.Id);
        //     Console.WriteLine(article.Title);
        //     Console.WriteLine(article.Url);
        // }

        var courses = new List<Course>();
        var courseOOP = new Course("Fundamento OPP", "fundamentos-oop");
        var courseCsharp = new Course("Fundamento C#", "fundamentos-csharp");
        var courseAspnet = new Course("Fundamento ASP.NET", "fundamentos-aspnet");

        courses.Add(courseOOP);
        courses.Add(courseCsharp);
        courses.Add(courseAspnet);

        var careerDotNet = new Career("Especialista .NET", "especialista-dotnet");
        var careers = new List<Career>();
        careers.Add(careerDotNet);

        var careearItem2 = new CareerItem(2, "OPP","",null);
        var careearItem = new CareerItem(1, "Começe por aqui","",courseCsharp);
        var careearItem3 = new CareerItem(3, "Asp.NET","",courseAspnet);


        careerDotNet.Items.Add(careearItem2);
        careerDotNet.Items.Add(careearItem3);
        careerDotNet.Items.Add(careearItem);
        
        foreach (var career in careers)
        {
            Console.WriteLine(career.Title);
            foreach (var item in career.Items.OrderBy(x => x.Order))
            {
                Console.WriteLine($"{item.Order} - {item.Title}");
                Console.WriteLine(item.Course?.Title);
                Console.WriteLine(item.Course?.Level);

                foreach (var notification in item.Notifications)
                {
                    Console.WriteLine($"{notification.Property} - {notification.Message}");
                }

            }

            var payPalSubscription = new PayPalSubscription();
            var Student = new Student();
            Student.CreateSubscription(payPalSubscription);
        }




    }
}