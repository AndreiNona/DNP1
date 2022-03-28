using Application.DAO;
using Contracts;
using Entities;

namespace Application.Logic;

public class UserServiceImpl : IUserServe
{
    private IUserDAO DAO;
    public  Task<ICollection<User>> GetAsync()
    {
        return DAO.GetAsync();
    }

    public async Task<User> GetById(int id)
    {
        return await DAO.GetById(id);
    }

    public async Task<User> AddAsync(User user)
    {
        return await DAO.AddAsync(user);
       
    }

    public async Task DeleteAsync(int id)
    {
        DAO.DeleteAsync(id);
    }

    public async Task UpdateAsync(User user)
    {
        DAO.UpdateAsync(user);
    }
}