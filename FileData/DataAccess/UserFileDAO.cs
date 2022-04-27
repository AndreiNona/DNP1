using Application.DAO;
using Contracts;
using Entities;

namespace FileData;

public class UserFileDAO : IUserDAO
{
    
    private UserFileContext fileContext;

    public UserFileDAO(UserFileContext fileContext)
    {
        this.fileContext = fileContext;
    }

    public async Task<ICollection<User>> GetAsync()
    {
        ICollection<User> users = fileContext.Users;
        return users;
    }
    public async Task<User> GetUserByUsername(string accountName)
    {
        return  fileContext.Users.First(t => t.accountName==accountName);
    }

    public async Task<User> GetUserById(int id)
    {
        return  fileContext.Users.First(t => t.id==id);
    }

    public async Task AddUserAsync(User user)
    {
        if (fileContext.Users.Contains(user))
        {
            throw new Exception("Username already in use. Pleas try another one");
        }
        int largestId = fileContext.Users.Max(t => t.id);
        int nextId = largestId + 1;
        user.id = nextId;
        fileContext.Users.Add(user);
        fileContext.SaveChanges();
    }

    public async Task DeleteAsync(int id)
    {
        User toDelete = fileContext.Users.First(t => t.id == id);
        fileContext.Users.Remove(toDelete);
        fileContext.SaveChanges();
    }

    public async Task UpdateAsync(User user)
    {
        User toUpdate = fileContext.Users.First(t => t.id == user.id);
        toUpdate.username = user.username;
        toUpdate.role = user.role;
        toUpdate.accountName = user.accountName;
        toUpdate.password = user.password;
        toUpdate.SecurityLevel = user.SecurityLevel;
        fileContext.SaveChanges();
    }
}