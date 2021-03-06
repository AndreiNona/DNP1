using Entities;

namespace Application.DAO;

public interface IPostDAO
{
    public Task<ICollection<Post>> GetAsync();
    public Task<Post> GetPost(int id);
    public Task AddPostAsync(Post post);
    public Task DeleteAsync(int id);
    public Task UpdateAsync(Post post);
}