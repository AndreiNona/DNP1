
using Blazor.Authentification;
using Entities;

namespace Blazor.Services.Impls;

//Delete after testing
public class InMemoryUserService : IUserService
{
    public async Task<User?> GetUserAsync(string username)
    {
        User? find = users.Find(user => user.accountName.Equals(username));
        return find;
    }


    
    private List<User> users = new()
    {
        new User("Andrei", "Andrei", "Teacher", "Big bird", 5),
        new User("Maria", "oneTwo3FOUR", "Student", "F1 fan", 2001),
        new User("Anne", "password", "HeadOfDepartment", "Duck lover", 1975)        
    };
}