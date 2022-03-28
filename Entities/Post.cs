namespace Entities;

public class Post
{
    private String title;
    private String subtitle;
    private String content;
    private User Owner;

    public Post(string title, string subtitle, string content, User owner)
    {
        this.title = title;
        this.subtitle = subtitle;
        this.content = content;
        Owner = owner;
    }
}