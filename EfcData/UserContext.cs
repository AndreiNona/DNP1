using Entities;
using Microsoft.EntityFrameworkCore;

namespace EfcData;

public class UserContext : DbContext
{
    
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source = C:\Users\Andrei\RiderProjects\DNP1\EfcData\Storage.db");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(user => user.id);
        modelBuilder.Entity<Post>().HasKey(post => post.ID);
    }
    public void Seed()
    {
        if (Users.Any() || Posts.Any()) return;

        Post[] ps =
        {

            new Post("Lorem ipsum", "Lorem ipsum dolor sit amet. ","Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam eget ornare diam, quis molestie eros. Nulla pretium cursus lorem, a sollicitudin lacus fringilla eu. Duis porta vehicula eros. Proin vitae ligula at purus facilisis consectetur. Nunc non dapibus elit. Suspendisse eu felis eget lectus volutpat mattis. Proin vestibulum suscipit tempor. Phasellus elementum diam nec consectetur eleifend. Praesent eget quam posuere, fermentum ligula sed, accumsan lacus. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Donec est neque, vestibulum sed elit sit amet, euismod dictum arcu. Mauris sed elit lacus. Duis laoreet vel nulla non lacinia. Aenean ut condimentum magna."),
            new Post("Lorem ipsum", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. ","Duis efficitur, sapien at vestibulum pharetra, sem odio auctor turpis, in blandit massa erat id diam. Sed vel malesuada leo, nec varius magna. Proin sed nibh fringilla, finibus nibh sit amet, vehicula elit. Phasellus vulputate nulla at imperdiet iaculis. Vestibulum fringilla, nulla sed venenatis placerat, mi leo rhoncus tellus, et molestie mauris diam eu elit. Vestibulum non neque ligula. Aenean et dignissim nunc. "),
            new Post("Meowson", "A day in the life of a cat","Nunc pellentesque bibendum interdum. Maecenas mi lectus, luctus non tincidunt eget, mollis ac nunc. Aenean placerat, odio eu rutrum suscipit, nisl urna imperdiet dolor, faucibus venenatis libero nisl in dui. Fusce eleifend, justo in lobortis auctor, risus leo fringilla ex, sit amet mattis quam ex nec diam. Donec orci neque, ullamcorper ac tincidunt et, mollis dictum arcu. Sed scelerisque dui sed metus pretium facilisis. Cras fringilla lorem ac accumsan laoreet. Donec quis lacus eget dolor laoreet eleifend et quis velit. Maecenas quis magna lacinia lorem congue condimentum sed ac velit. Cras eleifend, nisl non lobortis laoreet, metus magna auctor enim, quis efficitur felis neque at arcu. Aenean a nisi enim. Aliquam vitae mi eget dui tincidunt egestas. Sed vulputate ligula bibendum malesuada tempus. Curabitur ut dui eget mauris rutrum posuere a sit amet nulla. Proin at feugiat urna. Interdum et malesuada fames ac ante ipsum primis in faucibus. "),
            new Post("A post about DBS", "DBS is one of the most important needs in life","Duis efficitur, sapien at vestibulum pharetra, sem odio auctor turpis, in blandit massa erat id diam. Sed vel malesuada leo, nec varius magna. Proin sed nibh fringilla, finibus nibh sit amet, vehicula elit. Phasellus vulputate nulla at imperdiet iaculis. Vestibulum fringilla, nulla sed venenatis placerat, mi leo rhoncus tellus, et molestie mauris diam eu elit. Vestibulum non neque ligula. Aenean et dignissim nunc. "),
            new Post("Meowson the second", "Another day in the life of a kitten","Nunc pellentesque bibendum interdum. Maecenas mi lectus, luctus non tincidunt eget, mollis ac nunc. Aenean placerat, odio eu rutrum suscipit, nisl urna imperdiet dolor, faucibus venenatis libero nisl in dui. Fusce eleifend, justo in lobortis auctor, risus leo fringilla ex, sit amet mattis quam ex nec diam. Donec orci neque, ullamcorper ac tincidunt et, mollis dictum arcu. Sed scelerisque dui sed metus pretium facilisis. Cras fringilla lorem ac accumsan laoreet. Donec quis lacus eget dolor laoreet eleifend et quis velit. Maecenas quis magna lacinia lorem congue condimentum sed ac velit. Cras eleifend, nisl non lobortis laoreet, metus magna auctor enim, quis efficitur felis neque at arcu. Aenean a nisi enim. Aliquam vitae mi eget dui tincidunt egestas. Sed vulputate ligula bibendum malesuada tempus. Curabitur ut dui eget mauris rutrum posuere a sit amet nulla. Proin at feugiat urna. Interdum et malesuada fames ac ante ipsum primis in faucibus."),

        };
        Posts.AddRange(ps);
        SaveChanges();
        User[] us =
        {

            new User("Andrei","Andrei" ,"Admin","Aneternums",5),
            new User("Nemo","123456" ,"Owner","Nemo",1986),
            new User("Freja","NemoIsTheCute" ,"Admin","Freja!\u003C3 Tilteprinsessen",5),
            new User("JohnJhonson","Johniscoll" ,"Guest","JJ",1),
            new User("Peseca","Mrrreoww" ,"Guest","Sir kitten",1),

        };
        Users.AddRange(us);
        SaveChanges();
    }
}