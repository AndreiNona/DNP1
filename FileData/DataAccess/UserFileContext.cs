using System.Text.Json;
using Entities;

namespace FileData;

public class UserFileContext
{
    private string userFilePath = "users.json";
    private ICollection<User>? users;
    public ICollection<User> Users
    {
        get
        {
            if (users == null)
            {
                LoadData();
            }

            return users!;
        }
    }

    public UserFileContext()
    {
        if (!File.Exists(userFilePath))
        {
            Seed();
        }
    }
    
    private void Seed()
    {
        User[] us = {
            new User("Andrei", "Andrei", "Admin", "Aneternums", 5) {
            id = 1,
            },
            new User("Nemo", "Andrei", "Guest", "Nemo", 1986) {
                id = 2,
            },
            new User("Duck", "Andrei", "Guest", "Josh", 1986) {
                id = 3,
            },
            new User("Peseca", "Andrei", "Guest", "F1 fan", 1986) {
                id = 4,
            },
            new User("Oreo", "Andrei", "Guest", "Cutiepie", 1986) {
                id = 5,
            },
        };
        users = us.ToList();
        SaveChanges();
    }
    public async void SaveChanges()
    {
        string serialize = JsonSerializer.Serialize(Users, new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = false
        });
        await File.WriteAllTextAsync(userFilePath,serialize);
        users = null;
    }
    private void LoadData()
    {
        string content = File.ReadAllText(userFilePath);
        users = JsonSerializer.Deserialize<List<User>>(content);
    }
}