using Entities;

namespace Contracts;

public interface IUserService
{
    public Task<ICollection<User>> GetAsync();
    public Task<User> GetUserByUsername(string accountName);
    public Task<User> GetUserById(int id);
    public Task AddUserAsync(User user);
    public Task DeleteAsync(int id);
    public Task UpdateAsync(User user);
}