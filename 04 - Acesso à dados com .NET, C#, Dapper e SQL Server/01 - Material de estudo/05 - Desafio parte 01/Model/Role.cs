
using Dapper.Contrib.Extensions;

namespace Desafio.Model;


[Table("Role")]
public class Role : BaseModel
{
    public Role()
    {
        Users = new List<User>();
    }
    public string Name { get; set; }
    public string Slug { get; set; }

    [Write(false)]    
    public List<User> Users { get; set; }


    protected override bool IsValidObject(){
        if(string.IsNullOrEmpty(Name))
            return false;
        if(string.IsNullOrEmpty(Slug))
            return false;
        
        return true;
    }

    public override string ToString() => $"\nId: {Id}\nCategoria: {Name}\nSlug: {Slug}\n";
 
}