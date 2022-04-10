using Entities;

namespace Contracts;

public interface IUserService
{
    public Task<ICollection<User>> GetAsync();
    public Task<User> GetUser(string username);
    public Task AddUserAsync(User user);
    public Task DeleteAsync(int id);
    public Task UpdateAsync(User user);
}