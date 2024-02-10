
using System;
using System.Text;
using Dapper.Contrib.Extensions;

namespace Desafio.Model;


[Table("[User]")]
public class User : BaseModel
{
    public User()
    {
        Roles = new List<Role>();
    }

 
    private string _passwordHash;

    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { 
        get {
            var bytesTexto = Convert.FromBase64String(_passwordHash);
            return Encoding.UTF8.GetString(bytesTexto);
        } 
        set{
            var bytesTexto = Encoding.UTF8.GetBytes(value);
            _passwordHash = Convert.ToBase64String(bytesTexto);
        }
    }
    public string Bio { get; set; }
    public string Image { get; set; }
    public string Slug { get; set; }

    [Write(false)]    
    public List<Role> Roles { get; set; }

    protected override bool IsValidObject(){
        if(string.IsNullOrEmpty(Name))
            return false;
        if(string.IsNullOrEmpty(_passwordHash))
            return false;
        if(string.IsNullOrEmpty(Bio))
            return false;
        if(string.IsNullOrEmpty(Image))
            return false;
        if(string.IsNullOrEmpty(Slug))
            return false;

        return true;
    }

    public override string ToString()
      => $" Nome: {Name}\n Email: {Email}\n Bio: {Bio}\n Image: {Image}\n Slug: {Slug}";
  
}