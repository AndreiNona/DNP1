using Application.DAO;
using Contracts;
using Entities;

namespace Application.Logic;

public class PostServiceImpl : IPostService
{
    private IPostDAO DAO;

    public PostServiceImpl(IPostDAO dao)
    {
        DAO = dao;
    }

    public  Task<ICollection<Post>> GetAsync()
    {
        return DAO.GetAsync();
    }

    public Task<Post> GetPost(int id)
    {
        return DAO.GetPost(id);
    }
    

    public async Task AddPostAsync(Post post)
    {
        await DAO.AddPostAsync(post);
       
    }

    public async Task DeleteAsync(int id)
    {
        await DAO.DeleteAsync(id);
    }

    public async Task UpdateAsync(Post post)
    {
        await DAO.UpdateAsync(post);
    }
}