class Program{
    static public void Main(string[] args)
    {
        Console.Clear();

        try
        {
            // var array = new int[3];

            // for(int i = 0; i< 10; i++)
            // {
            //     Console.WriteLine(array[i]);
            // }
            Salvar(null);
        }
        catch(MeuErro ex){
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.QuandoAconteceu);
            Console.WriteLine("Algo deu errado");
        }
        catch(ArgumentNullException ex){
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.InnerException);
            Console.WriteLine("Algo deu errado");
        }
        catch(IndexOutOfRangeException ex){
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.InnerException);
            Console.WriteLine("Algo deu errado");
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.InnerException);
            Console.WriteLine("Algo deu errado");
        }
        finally{
            Console.WriteLine("Passou por aqui");
        }
      
    }

    static void Salvar(string texto)
    {
        if(string.IsNullOrEmpty(texto))
            //throw new Exception("O texto não pode ser nulo");
            throw new MeuErro();
    }

    public class MeuErro : Exception{
        public DateTime QuandoAconteceu{get;set;} = DateTime.Now;
    }
}
