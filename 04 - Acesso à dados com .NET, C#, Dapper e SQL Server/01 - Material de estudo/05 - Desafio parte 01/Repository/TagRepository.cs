
using Desafio.Model;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Dapper;

namespace Desafio.Repository;


public class TagRepository : Repository<Tag> 
{
    public TagRepository(SqlConnection connection) : base(connection)
    {

    }

    public List<Tag> GetAllWithPost()
    {
        var query = @"SELECT [Tag].*, [Post].* FROM [Tag] 
            LEFT JOIN [PostTag] ON [PostTag].[TagId] = [Tag].[Id] 
            LEFT JOIN [Post] ON [PostTag].[PostId] = [Post].[Id]";

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

            }, splitOn:"Id");
        return tags; 
    }

    public List<Tag> GetTagWithPost(int id)
    {
        var query = @"SELECT [Tag].*, [Post].* FROM [Tag] 
            LEFT JOIN [PostTag] ON [PostTag].[TagId] = [Tag].[Id] 
            LEFT JOIN [Post] ON [PostTag].[PostId] = [Post].[Id] WHERE [Role].[Id] = @Id";

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

            }, new{Id = id}, splitOn:"Id");
       return tags; 
    }


}