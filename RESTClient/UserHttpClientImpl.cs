using System.Text;
using System.Text.Json;
using Contracts;
using Entities;

namespace RESTClient;

public class UserHttpClientImpl : IUserService
{
    public async Task<ICollection<User>> GetAsync()
    {
        using HttpClient client = new ();
        HttpResponseMessage response = await client.GetAsync("https://localhost:7211/User");
        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {content}");
        }

        ICollection<User> users = JsonSerializer.Deserialize<ICollection<User>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        Console.WriteLine("GetUser returned: " + users); //Console line
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
        Console.WriteLine("GetUser returned: " + user); //Console line
        return user;
    }

    public async Task AddUserAsync(User user)
    {
        using HttpClient client = new ();
        
        string UserAsJson = JsonSerializer.Serialize(user);
        StringContent usercontent = new(UserAsJson, Encoding.UTF8, "application/json");
        
        HttpResponseMessage response = await client.PostAsync($"https://localhost:7211/User/Add",usercontent);
        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {content}");
        }
        User returned = JsonSerializer.Deserialize<User>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        
        Console.WriteLine("AddUserAsync returned: " + returned); //Console line
        
    }

    public async Task DeleteAsync(int id)
    {
        using HttpClient client = new ();
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7211/User/{id}");
        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {content}");
        }
    }

    public async Task UpdateAsync(User user)
    {
        using HttpClient client = new ();
        
        string UserAsJson = JsonSerializer.Serialize(user);
        StringContent usercontent = new(UserAsJson, Encoding.UTF8, "application/json");
        
        HttpResponseMessage response = await client.PostAsync($"https://localhost:7211/User/update",usercontent);
        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {content}");
        }
        User returned = JsonSerializer.Deserialize<User>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        
        Console.WriteLine("UpdateAsync returned: " + returned); //Console line
    }
}