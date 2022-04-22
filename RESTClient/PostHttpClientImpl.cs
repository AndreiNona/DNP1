using System.Text;
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

    public async Task<Post> GetPost(int id)
    {
        using HttpClient client = new ();
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7211/Post/{id}");
        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {content}");
        }

        Post post = JsonSerializer.Deserialize<Post>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        Console.WriteLine("GetPost returned: " + post.title); //Console line
        return post;
    }

    public async Task AddPostAsync(Post post)
    {
        using HttpClient client = new ();
        
        string postAsJson = JsonSerializer.Serialize(post);
        StringContent postcontent = new(postAsJson, Encoding.UTF8, "application/json");
        
        HttpResponseMessage response = await client.PostAsync($"https://localhost:7211/Post/Add",postcontent);
        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {content}");
        }
        Post returned = JsonSerializer.Deserialize<Post>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        
        Console.WriteLine("AddPostAsync returned: " + returned); //Console line
    }

    public async Task DeleteAsync(int id)
    {
        using HttpClient client = new ();
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7211/Post/{id}");
        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {content}");
        }
    }

    public async Task UpdateAsync(Post post)
    {
        using HttpClient client = new ();
        
        string PostAsJson = JsonSerializer.Serialize(post);
        StringContent postcontent = new(PostAsJson, Encoding.UTF8, "application/json");
        
        HttpResponseMessage response = await client.PostAsync($"https://localhost:7211/Post/update/",postcontent);
        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {content}");
        }
        Post returned = JsonSerializer.Deserialize<Post>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        
        Console.WriteLine("UpdateAsync returned: " + returned); //Console line
    }
}