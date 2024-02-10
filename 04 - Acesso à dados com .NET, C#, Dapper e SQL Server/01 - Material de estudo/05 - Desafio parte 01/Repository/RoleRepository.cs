
using Desafio.Model;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Dapper;

namespace Desafio.Repository;


public class RoleRepository : Repository<Role> 
{
   public RoleRepository(SqlConnection connection) : base(connection)
   {

   }

   public List<Role> GetAllWithUsers()
    {
        var query = @"SELECT [Role].*, [User].* FROM [Role] 
            LEFT JOIN [UserRole] ON [UserRole].[RoleId] = [Role].[Id] 
            LEFT JOIN [User] ON [UserRole].[UserId] = [User].[Id]";

        var roles = new List<Role>();

        _connection.Query<Role, User, Role>(query, 
            (role, user)=>{
               
                var item = roles.FirstOrDefault(w=>w.Id == role.Id);

                if(item is null)
                {
                    if(user is not null)
                      role.Users.Add(user);

                    roles.Add(role);
                }
                else
                {
                    if(user is not null)
                        item.Users.Add(user);
                }

                return role;

            }, splitOn:"Id");
       return roles; 
    }

   public List<Role> GetRoleWithUser(int id)
    {
        var query = @"SELECT [Role].*, [User].* FROM [Role] 
            LEFT JOIN [UserRole] ON [UserRole].[RoleId] = [Role].[Id] 
            LEFT JOIN [User] ON [UserRole].[UserId] = [User].[Id] WHERE [Role].[Id] = @Id";

        var roles = new List<Role>();

        _connection.Query<Role, User, Role>(query, 
            (role, user)=>{
               
                var item = roles.FirstOrDefault(w=>w.Id == role.Id);

                if(item is null)
                {
                    if(user is not null)
                      role.Users.Add(user);

                    roles.Add(role);
                }
                else
                {
                    if(user is not null)
                        item.Users.Add(user);
                }

                return role;

            }, new{Id = id}, splitOn:"Id");
       return roles; 
    }

   
}