using Contracts;
using Entities;

namespace FileData;

public class UserFileDAO : IUserServe
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
    public async Task<User> GetById(int id)
    {
        return fileContext.Users.First(t => t.ID == id);
    }

    public async Task<User> AddAsync(User user)
    {
        int largestId = fileContext.Users.Max(t => t.ID);
        int nextId = largestId + 1;
        user.ID = nextId;
        fileContext.Users.Add(user);
        fileContext.SaveChanges();
        return user;
    }

    public async Task DeleteAsync(int id)
    {
        User toDelete = fileContext.Users.First(t => t.ID == id);
        fileContext.Users.Remove(toDelete);
        fileContext.SaveChanges();
    }

    public async Task UpdateAsync(User user)
    {
        User toUpdate = fileContext.Users.First(t => t.ID == user.ID);
        fileContext.SaveChanges();
    }
}