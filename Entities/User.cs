namespace Entities;

public class User
{
    public  String accountName{ get;  set; }
    public  String password{ get;  set; }
    public  String role{ get;  set; }
    public  String username{ get;  set; }
    public  int SecurityLevel{ get; set; }
    public int ID { get; set; }

    public User(string accountName, string password)
    {
        this.accountName = accountName;
        this.password = password;
    }

    public User(string accountName, string password, int securityLevel)
    {
        this.accountName = accountName;
        this.password = password;
        SecurityLevel = securityLevel;
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