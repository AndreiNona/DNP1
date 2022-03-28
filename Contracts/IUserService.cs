using Entities;

namespace Contracts;

public interface IUserService
{
    public Task<ICollection<User>> GetAsync();
    public Task<User> GetById(int id);
    public Task<User> AddAsync(User user);
    public Task DeleteAsync(int id);
    public Task UpdateAsync(User user);
}