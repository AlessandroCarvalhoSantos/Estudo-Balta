using Microsoft.Data.SqlClient;
using Desafio.Model;
using Dapper.Contrib.Extensions;
using Desafio.Repository;

namespace Desafio.Controller;

public abstract class BaseController <T> where T : BaseModel 
{
    protected SqlConnection _connection;

    public BaseController(SqlConnection connection)
    {
        _connection = connection;
    }

    public virtual void SwitchOption(int opcao)
    {
        switch (opcao)
        {
            case 1:
                var model = GetModel();
                if(model is not null)
                    CreateModel(model);
            break;
            case 2:
                var models = ListModel();
                PrintListModel(models);
            break;
            case 3:
                var id = GetIdSearch();
                if(id > 0)
                    SearchModel(id);
            break;
            case 4:
                var updateModel = GetUpdateModel();
                if(updateModel is not null)
                    UpdateModel(updateModel);
            break;
            case 5:
                var idModelUpdate = GetIdSearch();
                if(idModelUpdate > 0)
                    DeleteModel(idModelUpdate);
            break;
            
        }
    }

    public virtual void CreateModel(T model)
    {
        var resposta = new Repository<T>(_connection).Create(model);

        if(resposta)
            Console.Write("Salvo com sucesso!!! Digite qualquer tecla para continuar: ");

        Console.ReadLine();
    }
    public virtual List<T> ListModel()
    {
        return new Repository<T>(_connection).GetAll();
    }
    public virtual void SearchModel(int id)
    {
        var model = new Repository<T>(_connection).GetById(id);

        if(model is null)
            Console.WriteLine("Não foi possível encontrar nenhum item com esse ID");
        else
            Console.WriteLine(model.ToString());

        Console.Write("Digite qualquer tecla para continuar: ");
        Console.ReadLine();
    }
    public virtual void UpdateModel(T model)
    {
        var resposta = new Repository<T>(_connection).Update(model);

        if(resposta)
            Console.Write("Item atualizado com sucesso!!! Digite qualquer tecla para continuar: ");

        Console.ReadLine();
    }
    public virtual void DeleteModel(int id)
    {
        var model = new Repository<T>(_connection).GetById(id);

        if(model is null)
        {
            Console.WriteLine("Não foi possível encontrar nenhum item com esse ID");
        }
        else
        {
            if(new Repository<T>(_connection).Delete(model))
            {
                Console.WriteLine("item deletado com sucesso.");
            }
            else
            {
                Console.WriteLine("Houve um erro ao deletar, tente novamente.");
            }
        }

        Console.Write("Digite qualquer tecla para continuar: ");
        Console.ReadLine();
    }

 
    public virtual T GetModel()
    { 
      T model = Activator.CreateInstance<T>();

      do
      {
        Console.Clear();
        PrintMenu();

        model = GetDataInfoModel();

        if(!model.IsValid)
        {
          Console.WriteLine("Algo de errado com os dados, revise e tente novamente.");
          Console.Write("Digite ESC para encerrar ou qualquer tecla para continuar: ");
          var key = Console.ReadKey();

          if(key.Key == ConsoleKey.Escape)
            return null;
          
        }
      }while(!model.IsValid);

      
      return model;
    }
    public virtual void PrintListModel(List<T> modelList)
    {
      Console.Clear();
      PrintMenu();

      foreach (var model in modelList)
      {
        Console.WriteLine(model.ToString());
      }

      if(modelList.Count() == 0)
        Console.WriteLine("Nenhuma categoria encontrada!");

      Console.Write("Digite qualquer tecla para continuar: ");
      Console.ReadLine();
    }
    public virtual int GetIdSearch()
    { 
        int id;
        do
        {
            Console.Clear();
            PrintMenu();
            Console.Write("Digite o id: ");
            int.TryParse(Console.ReadLine(), out id);

            if(id == 0)
            {
                Console.WriteLine("Esse id não é válido.");
                Console.Write("Digite ESC para encerrar ou qualquer tecla para continuar: ");
                var key = Console.ReadKey();

                if(key.Key == ConsoleKey.Escape)
                return -1;
            }

        }while(id <= 0);

        return id;
    }
    public virtual T GetUpdateModel()
    { 
      T model = Activator.CreateInstance<T>();

      do
      {
        Console.Clear();
        PrintMenu();

        int id;
        Console.Write("Digite o Id: ");
        int.TryParse(Console.ReadLine(), out id);
        model.Id = id;

        model = GetDataInfoModel();

        if(!model.IsValid)
        {
          Console.WriteLine("Algo de errado com os dados, revise e tente novamente.");
          Console.Write("Digite ESC para encerrar ou qualquer tecla para continuar: ");
          var key = Console.ReadKey();

          if(key.Key == ConsoleKey.Escape)
            return null;
          
        }
      }while(!model.IsValid);

      
      return model;
    }
    
    protected virtual void PrintMenu(){}
    public virtual T GetDataInfoModel(){ return null;}
  
}