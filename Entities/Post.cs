using System.ComponentModel.DataAnnotations;

namespace Entities;

public class Post
{
    [Required,MaxLength(32)]
    public String title{ get; set; }
    [Required,MaxLength(64)]
    public String subtitle{ get; set; }
    [Required,MaxLength(6000)]
    public String content{ get; set; }
    //public User Owner;
    public int ID { get; set; }

    public Post()
    {
    }
    //, User owner
    public Post(string title, string subtitle, string content)
    {
        this.title = title;
        this.subtitle = subtitle;
        this.content = content;
        //Owner = owner;
    }
}