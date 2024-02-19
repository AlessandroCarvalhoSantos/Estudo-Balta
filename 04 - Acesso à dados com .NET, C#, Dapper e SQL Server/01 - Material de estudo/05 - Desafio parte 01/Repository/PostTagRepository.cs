
using Desafio.Model;
using Microsoft.Data.SqlClient;

namespace Desafio.Repository;


public class PostTagRepository : Repository<PostTag> 
{
  public PostTagRepository(SqlConnection connection) : base(connection)
  {

  }
}