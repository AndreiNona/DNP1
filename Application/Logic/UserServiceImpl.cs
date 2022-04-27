using Application.DAO;
using Contracts;
using Entities;

namespace Application.Logic;

public class UserServiceImpl : IUserService
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
    

    public async Task<User> GetUserByUsername(string accountName)
    {
        return await DAO.GetUserByUsername(accountName);
    }

    public async Task<User> GetUserById(int id)
    {
        return await DAO.GetUserById(id);
    }

    public async Task AddUserAsync(User user)
    {
         await DAO.AddUserAsync(user);
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