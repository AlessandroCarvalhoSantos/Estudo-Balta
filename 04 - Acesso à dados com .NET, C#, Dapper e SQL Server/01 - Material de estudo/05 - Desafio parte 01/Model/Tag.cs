
using Dapper.Contrib.Extensions;

namespace Desafio.Model;


[Table("Tag")]
public class Tag : BaseModel
{
    public Tag()
    {
        Posts = new List<Post>();
    }
    public string Name { get; set; }
    public string Slug { get; set; }

    [Write(false)]    
    public List<Post> Posts { get; set; }

    protected override bool IsValidObject(){
        if(string.IsNullOrEmpty(Name))
            return false;
        if(string.IsNullOrEmpty(Slug))
            return false;
        
        return true;
    }

    public override string ToString() => $"\nId: {Id}\nTag: {Name}\nSlug: {Slug}\n";


}