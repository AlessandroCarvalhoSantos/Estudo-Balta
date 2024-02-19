
using Desafio.Model;
using Microsoft.Data.SqlClient;

namespace Desafio.Repository;


public class UserRoleRepository : Repository<UserRole> 
{
    public UserRoleRepository(SqlConnection connection) : base(connection)
    {

    }
}