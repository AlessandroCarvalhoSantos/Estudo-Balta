
using Desafio.Model;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Dapper;

namespace Desafio.Repository;


public class PostRepository : Repository<Post> 
{
    public PostRepository(SqlConnection connection) : base(connection)
    {

    }

    public List<Post> GetAllWithAssociados(int id = 0)
    {
    
        var query = @"SELECT [Post].*, [Tag].*,  [User].*,[Category].* FROM [Post] 
            LEFT JOIN [PostTag] ON [PostTag].[PostId] = [Post].[Id] 
            LEFT JOIN [Tag] ON [PostTag].[TagId] = [Tag].[Id]
            LEFT JOIN [User] ON [User].[Id] = [Post].[AuthorId]
            LEFT JOIN [Category] ON [Category].[Id] = [Post].[CategoryId]";

        if(id > 0)
        {
            query += " WHERE [Post].[Id] = @Id";
        }

        var posts = new List<Post>();

        _connection.Query<Post, Tag,User, Category, Post>(query, 
            (post, tag, user, category)=>{
               
                var item = posts.FirstOrDefault(w=>w.Id == post.Id);

                if(item is null)
                {
                    if(tag is not null)
                    {
                      post.Tags.Add(tag);
                    }
                    post.Category = category;
                    post.Author = user;
                    posts.Add(post);
                }
                else
                {
                    if(tag is not null)
                        item.Tags.Add(tag);
                }

                return post;

            }, id>0?new{Id = id}:null,splitOn:"Id");
        return posts; 
    }
}