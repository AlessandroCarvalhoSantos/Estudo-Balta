
using Dapper;
using Desafio.Model;
using Microsoft.Data.SqlClient;

namespace Desafio.Repository;

public class TagRepository : Repository<Tag> 
{
    public TagRepository(SqlConnection connection) : base(connection)
    {

    }

    public List<Tag> GetAllWithPost(int id = 0)
    {
        var query = @"SELECT [Tag].*, [Post].* FROM [Tag] 
            LEFT JOIN [PostTag] ON [PostTag].[TagId] = [Tag].[Id] 
            LEFT JOIN [Post] ON [PostTag].[PostId] = [Post].[Id]";

        if(id > 0)
           query +=  "WHERE [Tag].[Id] = @Id";

        var tags = new List<Tag>();

        _connection.Query<Tag, Post, Tag>(query, 
            (role, user)=>{
               
                var item = tags.FirstOrDefault(w=>w.Id == role.Id);

                if(item is null)
                {
                    if(user is not null)
                      role.Posts.Add(user);

                    tags.Add(role);
                }
                else
                {
                    if(user is not null)
                        item.Posts.Add(user);
                }

                return role;

            }, id>0?new{Id = id}:null, splitOn:"Id");
        return tags; 
    }
}