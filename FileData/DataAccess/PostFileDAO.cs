using Application.DAO;
using Entities;

namespace FileData;

public class PostFileDAO : IPostDAO
{
        
    private PostFileContext fileContext;

    public PostFileDAO(PostFileContext fileContext)
    {
        this.fileContext = fileContext;
    }

    public async Task<ICollection<Post>> GetAsync()
    {
        ICollection<Post> posts = fileContext.Posts;
        return posts;
    }
    public async Task<Post> GetPost(int id)
    {
        return  fileContext.Posts.First(t => t.ID == id);
    }

    public async Task<Post> AddAsync(Post post)
    {
        int largestId = fileContext.Posts.Max(t => t.ID);
        int nextId = largestId + 1;
        post.ID = nextId;
        fileContext.Posts.Add(post);
        fileContext.SaveChanges();
        return post;
    }

    public async Task DeleteAsync(int id)
    {
        Post toDelete = fileContext.Posts.First(t => t.ID == id);
        fileContext.Posts.Remove(toDelete);
        fileContext.SaveChanges();
    }

    public async Task UpdateAsync(Post post)
    {
        Post toUpdate = fileContext.Posts.First(t => t.ID == post.ID);
        toUpdate.title = post.title;
        toUpdate.subtitle = post.subtitle;
        toUpdate.content = post.content;
        await fileContext.SaveChanges();
    }
}