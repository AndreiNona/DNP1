using Entities;
using Microsoft.EntityFrameworkCore;

namespace EfcData;

public class UserContext : DbContext
{
    
    public DbSet<User> Users { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source = C:\Users\Andrei\RiderProjects\DNP1\EfcData\Storage.db");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(user => user.id);
    }
    public void Seed()
    {
        if (Users.Any()) return;

        User[] ts =
        {

            new User("Andrei","Andrei" ,"Admin","Aneternums",5),
            new User("Nemo","123456" ,"Owner","Nemo",1986),
            new User("Freja","NemoIsTheCute" ,"Admin","Freja!\u003C3 Tilteprinsessen",5),
            new User("JohnJhonson","Johniscoll" ,"Guest","JJ",1),
            new User("Peseca","Mrrreoww" ,"Guest","Sir kitten",1),

        };
        Users.AddRange(ts);
        SaveChanges();
    }
}