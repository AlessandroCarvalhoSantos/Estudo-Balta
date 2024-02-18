
using Dapper.Contrib.Extensions;

namespace Desafio.Model;


[Table("Category")]
public class Category : BaseModel
{
    
    public string Name { get; set; }
    public string Slug { get; set; }

    protected override bool IsValidObject(){
        if(string.IsNullOrEmpty(Name))
            return false;
        if(string.IsNullOrEmpty(Slug))
            return false;
        
        return true;
    }

    public override string ToString()
    => $"\nId: {Id}\nCategoria: {Name}\nSlug: {Slug}";
    
}