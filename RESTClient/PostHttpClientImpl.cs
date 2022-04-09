using System.Text.Json;
using Contracts;
using Entities;

namespace RESTClient;

public class PostHttpClientImpl : IPostService
{
    public async Task<ICollection<Post>> GetAsync()
    {
        using HttpClient client = new ();
        HttpResponseMessage response = await client.GetAsync("https://localhost:7211/Post");
        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {content}");
        }

        ICollection<Post> posts = JsonSerializer.Deserialize<ICollection<Post>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return posts;
    }

    public Task<Post> GetPost(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Post> AddAsync(Post post)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Post post)
    {
        throw new NotImplementedException();
    }
}