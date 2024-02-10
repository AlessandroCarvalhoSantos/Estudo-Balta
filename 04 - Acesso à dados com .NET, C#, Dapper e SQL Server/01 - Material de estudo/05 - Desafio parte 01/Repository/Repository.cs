
using Desafio.Model;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Dapper;

namespace Desafio.Repository;


public class Repository<T> where T : BaseModel
{
   protected readonly SqlConnection _connection;

   public Repository(SqlConnection connection)
   {
        _connection = connection;
   }

    public T GetById(int id) => _connection.Get<T>(id);

    public List<T> GetByIds(string[] id)
     {
        var query = "SELECT * FROM [User] WHERE [Id] = @Id"; 
        return (List<T>)_connection.Query(query, new {Id = id});
     }

    public List<T> GetAll() => (List<T>)_connection.GetAll<T>();

    public bool Create(T model)
    {
        var rowsAffected = 0L;

        if(model.IsValid && model.Id == 0)
            rowsAffected = _connection.Insert<T>(model);
        
        return rowsAffected > 0;
    }

    public bool CreateList(List<T> modelList)
    {
        var rowsAffected = 0L;

        var items = modelList.Where(e => !e.IsValid || e.Id != 0);

        if(items.Count()==0)
            rowsAffected = _connection.Insert<List<T>>(modelList);
        
        return rowsAffected > 0;
    }

    public bool Update(T model)
    {
        if(model.IsValid && model.Id > 0)
            return  _connection.Update<T>(model);
        
        return false;
    }

    public bool UpdateList(List<T> modelList)
    {
        var items = modelList.Where(e => !e.IsValid || e.Id != 0);

        if(items.Count()==0)
            return  _connection.Update<List<T>>(modelList);
        
        return false;
    }

    public bool Delete(T model)
    {
        return _connection.Delete<T>(model);
    }

    public bool DeleteList(List<T> modelList)
    {
        return _connection.Delete<List<T>>(modelList);
    }

    public bool DeleteList(string[] id)
    {
        var model = GetByIds(id);

        if(model != null)
            return DeleteList(model);
        
        return false;
    }
    
}