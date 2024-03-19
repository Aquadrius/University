using System.ComponentModel.DataAnnotations;

namespace University.Dto
{
    public class LoginRequest
    {
       public string? Email { get; set; }
       public string? Password { get; set;}
       public string? UserName { get;}
    }
}
