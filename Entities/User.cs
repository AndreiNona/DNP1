using System.ComponentModel.DataAnnotations;

namespace Entities;

public class User
{
    public  String accountName{ get;  set; }
    [Required, MinLength(5)] 
    public  String password{ get;  set; }
    public  String role{ get;  set; }
    [Required, MaxLength(128)] 
    public  String username{ get;  set; }
    public  int SecurityLevel{ get; set; }
    public int id { get; set; }


    public User()
    {
    }

    public User(string accountName, string password, string role, string username, int securityLevel)
    {
        this.accountName = accountName;
        this.password = password;
        this.role = role;
        this.username = username;
        SecurityLevel = securityLevel;
    }
}