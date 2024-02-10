
using Desafio.Model;
using Microsoft.Data.SqlClient;

namespace Desafio.Repository;


public class CategoryRepository : Repository<Category> 
{
   public CategoryRepository(SqlConnection connection) : base(connection)
   {

   }
}