using System.Globalization;

namespace DatetimeAula;


public class Program
{
    public static void Main(string[] args)
    {
        Console.Clear();
        DateTime data = new DateTime();
        Console.WriteLine(data);

        DateTime? dataNula = null;

        DateTime dataAtual = DateTime.Now;
        Console.WriteLine(dataAtual);

        
        
        Console.WriteLine(DateTime.DaysInMonth(2020,2));

        DateTime dataModificada = new DateTime(2023,01,01,23,20,21);
        Console.WriteLine(dataModificada);

        Console.WriteLine(dataModificada.Year);
        Console.WriteLine(dataModificada.Month);
        Console.WriteLine(dataModificada.Day);
        Console.WriteLine(dataModificada.Hour);
        Console.WriteLine(dataModificada.Minute);
        Console.WriteLine(dataModificada.Second);

        Console.WriteLine(dataModificada.DayOfWeek);
        Console.WriteLine(dataModificada.DayOfYear);


        var formatada = string.Format("{0:d/m/YYYY z  zz  zzz  zzzz}", dataAtual);
        Console.WriteLine(formatada);
        Console.WriteLine($"{dataAtual:d/m/YYYY}");

        Console.WriteLine($"{dataAtual:t}"); //22:46
        Console.WriteLine($"{dataAtual:T}"); //22:46:18
        Console.WriteLine($"{dataAtual:d}"); //23/12/2023
        Console.WriteLine($"{dataAtual:D}"); //sábado, 23 de dezembro de 2023
        Console.WriteLine($"{dataAtual:f}"); //sábado, 23 de dezembro de 2023 22:46
        Console.WriteLine($"{dataAtual:F}"); //sábado, 23 de dezembro de 2023 22:46:18

        Console.WriteLine($"{dataAtual:g}"); //23/12/2023 22:46
        Console.WriteLine($"{dataAtual:G}"); //23/12/2023 22:46:18

        Console.WriteLine($"{dataAtual:R}"); //Sat, 23 Dec 2023 22:46:18 GMT
        Console.WriteLine($"{dataAtual:r}"); //Sat, 23 Dec 2023 22:46:18 GMT

        Console.WriteLine($"{dataAtual:s}"); //2023-12-23T22:46:18

        Console.WriteLine($"{dataAtual:u}"); //2023-12-23 22:48:37Z
        Console.WriteLine($"{dataAtual:U}"); //domingo, 24 de dezembro de 2023 01:48:37


        DateTime today = DateTime.Now;
        DateTime tomorrow = today.AddDays(1); // Adiciona 1 dia

        DateTime now = DateTime.Now;
        DateTime twoHoursLater = now.AddHours(2); // Adiciona 2 horas

        DateTime currentTime = DateTime.Now;
        DateTime thirtyMinutesLater = currentTime.AddMinutes(30); // Adiciona 30 minutos

        DateTime date = new DateTime(2023, 1, 1);
        DateTime dateNextMonth = date.AddMonths(1); // Adiciona 1 mês

        DateTime dateYear = new DateTime(2023, 1, 1);
        DateTime dateNextYear = dateYear.AddYears(1); // Adiciona 1 ano


        DateTime time = DateTime.Now;
        DateTime thirtySecondsLater = time.AddSeconds(30); // Adiciona 30 segundos


        if(DateTime.Now == dataAtual)
            Console.WriteLine("É igual");

        
        if(DateTime.Now.Date < dataAtual.Date)
            Console.WriteLine("É igual");


        var pt = new CultureInfo("pt-PT");
        var br = new CultureInfo("pt-BR");
        var en = new CultureInfo("en-US");
        var de = new CultureInfo("de-DE");

        Console.WriteLine(dataAtual.ToString("d"));

        Console.WriteLine(dataAtual.ToString(pt));
        Console.WriteLine(dataAtual.ToString(br));
        Console.WriteLine(dataAtual.ToString(en));
        Console.WriteLine(dataAtual.ToString(de));

        var culturaAtual = CultureInfo.CurrentCulture;
        Console.WriteLine(culturaAtual);

        var dataUtc = DateTime.UtcNow;
        Console.WriteLine(dataUtc);
        Console.WriteLine(dataUtc.ToLocalTime());


        var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific/Auckland");

        var dataModificadaUtc = TimeZoneInfo.ConvertTimeFromUtc(dataUtc, timeZone);
        Console.WriteLine(dataModificadaUtc);

        var dataModificadaInUtc = TimeZoneInfo.ConvertTimeToUtc(dataAtual);
        Console.WriteLine(dataModificadaInUtc);


        var timeZones = TimeZoneInfo.GetSystemTimeZones();

        foreach (var item in timeZones)
        {
            Console.WriteLine(item.Id);
            Console.WriteLine(item);
            Console.WriteLine(TimeZoneInfo.ConvertTimeFromUtc(dataUtc, item));
            Console.WriteLine("---------");

        }



        TimeSpan horarioVazio = new TimeSpan();
        Console.WriteLine(horarioVazio);

        TimeSpan nanoSegundos = new TimeSpan(1);
        Console.WriteLine(nanoSegundos);

        TimeSpan horario = new TimeSpan(1,2,10);
        Console.WriteLine(horario);

        TimeSpan horarioDia = new TimeSpan(5,1,2,10);
        Console.WriteLine(horarioDia);

        TimeSpan horarioDiaMilissegundos = new TimeSpan(5,1,2,10,100);
        Console.WriteLine(horarioDiaMilissegundos);


        TimeSpan a = new TimeSpan(1,10,0);
        TimeSpan b = new TimeSpan(0,10,0);
        Console.WriteLine(a-b);
        Console.WriteLine(a.Hours);

        a.Add(new TimeSpan(100));

        Console.WriteLine(FinalSemana(DateTime.Now.DayOfWeek));

          Console.WriteLine(DateTime.Now.IsDaylightSavingTime());
    
    }

    static bool FinalSemana(DayOfWeek day)
    {
        return day == DayOfWeek.Sunday || day == DayOfWeek.Saturday;
    }
}