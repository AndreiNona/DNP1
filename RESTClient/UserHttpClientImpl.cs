using System.Text.Json;
using Contracts;
using Entities;

namespace RESTClient;

public class UserHttpClientImpl : IUserService
{
    public async Task<ICollection<User>> GetAsync()
    {
        using HttpClient client = new ();
        HttpResponseMessage response = await client.GetAsync("https://localhost:7211/User/users");
        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {content}");
        }

        ICollection<User> users = JsonSerializer.Deserialize<ICollection<User>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return users;
    }

    public async Task<User> GetUser(string username)
    {
        using HttpClient client = new ();
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7211/User/{username}");
        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {content}");
        }

        User user = JsonSerializer.Deserialize<User>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return user;
    }

    public Task AddUserAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }
}