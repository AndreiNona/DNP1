namespace Entities;

public class Forum
{
    private ICollection<User> users;
    private ICollection<Post> posts;

    public Forum()
    {
        users = new List<User>();
        posts = new List<Post>();
    }
}