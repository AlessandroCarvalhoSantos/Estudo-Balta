
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

    public List<User> GetAllWithRoles(int id = 0)
    {
    
        var query = @"SELECT [User].*, [Role].* FROM [User] 
            LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id] 
            LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]";

        if(id > 0)
        {
            query += " WHERE [User].[Id] = @Id";
        }

        var users = new List<User>();

        _connection.Query<User, Role, User>(query, 
            (user, role)=>{
               
                var item = users.FirstOrDefault(w=>w.Id == user.Id);

                if(item is null)
                {
                    if(role is not null)
                      user.Roles.Add(role);

                    users.Add(user);
                }
                else
                {
                    if(role is not null)
                        item.Roles.Add(role);
                }

                return user;

            }, id>0?new{Id = id}:null,splitOn:"Id");
        return users; 
    }
}