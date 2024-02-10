using Microsoft.Data.SqlClient;
using Dapper.Contrib.Extensions;

namespace Projeto.Repositories;


public class Repository <T> where T : class
{
    protected readonly SqlConnection _sqlConnection;

    public Repository(SqlConnection connection) => _sqlConnection = connection;

    public IEnumerable<T> Get() => _sqlConnection.GetAll<T>();

    public T Get(string id) => _sqlConnection.Get<T>(id);
    
    public void Create(T model) => _sqlConnection.Insert<T>(model);
    
    public void Update(T model) => _sqlConnection.Update<T>(model);
    
    public void Delete(T model) =>  _sqlConnection.Delete<T>(model);
     
    public void Delete(int id){
        var model = _sqlConnection.Get<T>(id);
        _sqlConnection.Delete<T>(model);
    } 

}

 