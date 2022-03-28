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
    

    public async Task<Post> AddAsync(Post post)
    {
        return await DAO.AddAsync(post);
       
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