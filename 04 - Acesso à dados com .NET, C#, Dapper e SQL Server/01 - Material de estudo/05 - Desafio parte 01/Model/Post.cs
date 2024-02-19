
using Dapper.Contrib.Extensions;
using static System.Net.Mime.MediaTypeNames;

namespace Desafio.Model;


[Table("Post")]
public class Post : BaseModel
{

    public Post()
    {
        Tags = new List<Tag>();
    }
    public int CategoryId { get; set; }
    public int AuthorId { get; set; }
    public string Title { get; set; }
    public string Summary { get; set; }
    public string Body { get; set; }
    public string Slug { get; set; }
    public DateTime CreateDate {get;set;}
    public DateTime LastUpdateDate {get;set;}

    [Write(false)]
    public Category Category {get;set;}

    [Write(false)]
    public User Author {get;set;}

    [Write(false)]    
    public List<Tag> Tags { get; set; }


    protected override bool IsValidObject(){

        if(CategoryId < 1) return false;
        if(AuthorId < 1) return false;
        if(string.IsNullOrEmpty(Title)) return false;
        if(string.IsNullOrEmpty(Summary)) return false;
        if(string.IsNullOrEmpty(Body)) return false;
        if(string.IsNullOrEmpty(Slug)) return false;
        if(CreateDate > DateTime.Now) return false;
        if(LastUpdateDate > DateTime.Now) return false;
        
        return true;
    }
    public override string ToString()
    {
      var post = $"\nTítulo: {Title}\nSumário: {Summary}\nConteúdo: {Body}\nSlug: {Slug}";
      post += $"\nCriação: {CreateDate.ToString("dd/MM/yyyy hh:mm")}";
      post += $"\nUltima Atualização: {LastUpdateDate.ToString("dd/MM/yyyy hh:mm")}";

      if(Author is not null)
          post += $"\nAuthor: {Author.Name}";
      if(Category is not null)
          post += $"\nCategoria: {Category.Name}";

      return post;
    }
}