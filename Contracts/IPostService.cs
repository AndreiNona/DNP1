using Entities;

namespace Contracts;

public interface IPostService
{
    public Task<ICollection<Post>> GetAsync();
    public Task<Post> GetPost(int id);
    public Task<Post> AddAsync(Post post);
    public Task DeleteAsync(int id);
    public Task UpdateAsync(Post post);
}
