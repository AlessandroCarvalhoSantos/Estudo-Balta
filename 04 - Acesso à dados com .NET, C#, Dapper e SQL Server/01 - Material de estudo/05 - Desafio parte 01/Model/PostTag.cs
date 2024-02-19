
using System;
using System.Text;
using Dapper.Contrib.Extensions;

namespace Desafio.Model;


[Table("[PostTag]")]
public class PostTag : BaseModel
{
  public int PostId { get; set; }
  public int TagId { get; set; }


  [Write(false)]    
  public Post Post { get; set; }
  [Write(false)]    
  public Tag Tag { get; set; }

  protected override bool IsValidObject(){
    if(PostId < 1)
      return false;
    if(TagId < 1)
      return false;

    return true;
  }

  public override string ToString()
  {
    var post = $"\nId: {Id}\nPostId: {PostId}\nTagId: {TagId}\n";
    if(Post is not null)
        post += $"\nPost: {Post.Title}";
    if(Tag is not null)
        post += $"\nTag: {Tag.Name}";

    return post;
  }
}