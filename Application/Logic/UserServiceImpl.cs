using Application.DAO;
using Contracts;
using Entities;

namespace Application.Logic;

public class UserServiceImpl : IUserServe
{
    private IUserDAO DAO;

    public UserServiceImpl(IUserDAO dao)
    {
        DAO = dao;
    }

    public  Task<ICollection<User>> GetAsync()
    {
        return DAO.GetAsync();
    }

    public async Task<User> GetUser(string username)
    {
        return await DAO.GetUser(username);
    }

    public async Task<User> AddAsync(User user)
    {
        return await DAO.AddAsync(user);
       
    }

    public async Task DeleteAsync(int id)
    {
        await DAO.DeleteAsync(id);
    }

    public async Task UpdateAsync(User user)
    {
        await DAO.UpdateAsync(user);
    }
}