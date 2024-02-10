using Dapper.Contrib.Extensions;

namespace Desafio.Model;

public abstract class BaseModel
{
    [Write(false)]
    public bool IsValid { get => IsValidObject(); }
    
    public int Id { get; set; }

    protected virtual bool IsValidObject()
    {
        return false;
    }

}