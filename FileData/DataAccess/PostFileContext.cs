using System.Text.Json;
using Entities;

namespace FileData;

public class PostFileContext
{
    
    private string postFilePath = "posts.json";
    private ICollection<Post>? posts;
    public ICollection<Post> Posts
    {
        get
        {
            if (posts == null)
            {
                LoadData();
            }

            return posts!;
        }
    }

    public PostFileContext()
    {
        if (!File.Exists(postFilePath))
        {
            Seed();
        }
    }
    
    private void Seed()
    {
        Post[] po = {
            new Post("Ducks are cool", "Ducks are the most amazing thing to ever happen", "Quack" ) {
                ID = 1,
            },
            new Post("F1", "F2 bad F1 best", "Vrummmm") {
                ID = 2,
            },
        };
        posts = po.ToList();
        SaveChanges();
    }
    public void SaveChanges()
    {
        string serialize = JsonSerializer.Serialize(Posts);
        File.WriteAllText(postFilePath,serialize);
        posts = null;
    }
    private void LoadData()
    {
        string content = File.ReadAllText(postFilePath);
        posts = JsonSerializer.Deserialize<List<Post>>(content);
    }
}