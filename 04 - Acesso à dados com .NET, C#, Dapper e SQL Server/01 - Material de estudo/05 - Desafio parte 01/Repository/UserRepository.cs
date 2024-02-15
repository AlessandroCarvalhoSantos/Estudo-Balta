
using Desafio.Model;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Dapper;

namespace Desafio.Repository;


public class UserRepository : Repository<User> 
{
    public UserRepository(SqlConnection connection) : base(connection)
    {

    }
}