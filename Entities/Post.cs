namespace Entities;

public class Post
{
    public String title;
    public String subtitle;
    public String content;
    public User Owner;
    public int ID { get; set; }

    public Post()
    {
    }

    public Post(string title, string subtitle, string content, User owner)
    {
        this.title = title;
        this.subtitle = subtitle;
        this.content = content;
        Owner = owner;
    }
}