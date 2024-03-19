using System.Collections.Specialized;

namespace University.Domain.Entity
{
    public class User  
    {
        public User () { }
        public User(Guid id, string userName, string password,string email )
        {

            Id= id;
            UserName= userName;
            Password= password;
            Email= email;
        }  
        public Guid? Id { get;  set; }

        public string? UserName { get; set; } 

        public string? Name { get; set; }

        public string? Password { get;  set; } 

        public string? Email { get; set; }

        public string? Role { get; set; }

        public static User Create(Guid id, string userName, string password, string email)
        {
            return new User(id, userName, password,email);
        }



    }
}
