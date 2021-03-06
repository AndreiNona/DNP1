using Application.DAO;
using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcData;

public class PostSqliteDAO : IPostDAO
{
    private readonly UserContext context;
    
    public PostSqliteDAO(UserContext context)
    {
        this.context = context;
    }
    public async Task<ICollection<Post>> GetAsync()
    {
        ICollection<Post> posts = await context.Posts.ToListAsync();
        return posts;
    }

    public async Task<Post> GetPost(int id)
    {
        Post? post = await context.Posts.FindAsync(id); //Works as long as the ID is a the only primary key for Post
        return post;
    }

    public async Task AddPostAsync(Post post)
    {
        EntityEntry<Post> added = await context.AddAsync(post);
        await context.SaveChangesAsync();
        //return added.Entity; // For data about the result
    }

    public async Task DeleteAsync(int id)
    {
        Post? existing = await context.Posts.FindAsync(id);
        if (existing is null)
        {
            throw new Exception($"Could not find Post with id {id}. Nothing was deleted");
        }

        context.Posts.Remove(existing);
        await context.SaveChangesAsync();
    }

    public Task UpdateAsync(Post post)
    {
        context.Posts.Update(post);
        return context.SaveChangesAsync();
    }
}