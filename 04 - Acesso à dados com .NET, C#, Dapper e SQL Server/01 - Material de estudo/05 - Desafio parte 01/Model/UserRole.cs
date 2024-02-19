
using System;
using System.Text;
using Dapper.Contrib.Extensions;

namespace Desafio.Model;


[Table("[UserRole]")]
public class UserRole : BaseModel
{
    public int RoleId { get; set; }
    public int UserId { get; set; }


    [Write(false)]    
    public Role Role { get; set; }
    [Write(false)]    
    public User User { get; set; }

    protected override bool IsValidObject(){
        if(UserId < 1)
            return false;
        if(RoleId < 1)
            return false;

        return true;
    }

    public override string ToString()
    {
      var post = $"\nId: {Id}\nRoleId: {RoleId}\nUserId: {UserId}\n";
      if(User is not null)
          post += $"\nUsuário: {User.Name}";
      if(Role is not null)
          post += $"\nRole: {Role.Name}";

      return post;
    }
  
}