using System.Collections;
using Application.DAO;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcData;

public class UserSqliteDAO : IUserDAO
{
    private readonly UserContext context;
    
    public UserSqliteDAO(UserContext context)
    {
        this.context = context;
    }
    public async Task<ICollection<User>> GetAsync()
    {
        ICollection<User> users = await context.Users.ToListAsync();
        return users;
    }

    public async Task<User> GetUserByUsername(string accountName)
    {
        IQueryable<User> users = context.Users.AsQueryable();
        users = users.Where(u => u.accountName == accountName);
        ICollection<User> result = await users.ToListAsync();
        foreach (var item in result)
        {
            return item;
        }
        return null;
    }
    public async Task<User> GetUserById(int id)
    {
        User? user = await context.Users.FindAsync(id); //Works as long as the ID is a the only primary key for User
        return user;
    }
    public async Task AddUserAsync(User user)
    {
        EntityEntry<User> added = await context.AddAsync(user);
        await context.SaveChangesAsync();
        //return added.Entity; // For data about the result
    }

    public async Task DeleteAsync(int id)
    {
        User? existing = await context.Users.FindAsync(id);
        if (existing is null)
        {
            throw new Exception($"Could not find Post with id {id}. Nothing was deleted");
        }

        context.Users.Remove(existing);
        await context.SaveChangesAsync();
    }

    public Task UpdateAsync(User user)
    {
        context.Users.Update(user);
        return context.SaveChangesAsync();
    }
}