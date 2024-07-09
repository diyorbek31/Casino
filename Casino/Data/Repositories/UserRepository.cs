using Casino.Data.IRepositories;
using Casino.Domain.Configurations;
using Casino.Domain.Entities;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Casino.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly string path = Database.USER_PATH;

    public async Task<bool> DeleteByIdAysnc(int id)
    {
        List<User> people = new List<User>();
        bool IsUserAvailable = false;
        var users = await this.RetrievAllAsync();
        await File.WriteAllTextAsync(path, "");
        foreach (var user in users)
        {
            if (user.id == id)
            {
                IsUserAvailable = true;
                continue;
            }
            people.Add(user);
            
        }
        var str = JsonConvert.SerializeObject(people,Formatting.Indented);
        await File.AppendAllTextAsync(path, str);
        return IsUserAvailable;
    }

    public async Task<bool> InsertAsync(User user)
    {
        user.id = await GenerateIdAsync();
        var users = await this.RetrievAllAsync();
        users.Add(user);
        var str = JsonConvert.SerializeObject(users,Formatting.Indented);
        await File.WriteAllTextAsync(path, str);
        
        return true;
    }

   
    public async Task<User> RetrievByIdAsync(int id)
    {
        var users = await this.RetrievAllAsync();
        foreach ( var user in users )
        {
            if (user.id == id)
                return user;
        }
        return null;
    }
    public async Task<List<User>> RetrievAllAsync()
    {
        string models = await File.ReadAllTextAsync(path);
        if (string.IsNullOrEmpty(models))
            models = "[]";
        var results = JsonConvert.DeserializeObject<List<User>>(models);
        return results;
    }

    public async Task<bool> UpdateAsync(User user)
    {
        bool IsUserAvailable = false;
        var users = await this.RetrievAllAsync();
        await File.WriteAllTextAsync(path, "[]");
        foreach(var person in users)
        {
            if(person.id == user.id)
            {
                person.FirstName = user.FirstName;
                person.LastName = user.LastName;
                person.Password = user.Password;
                person.Username = user.Username;
                person.Budget = user.Budget;
                IsUserAvailable = true;
            }
        }

        var str = JsonConvert.SerializeObject(users);
        await File.WriteAllTextAsync(path, str);
        return IsUserAvailable;
    }

    public async Task WriteToFileAsync(User user)
    {
        var str = $"{user.id}|{user.FirstName}|{user.LastName}|{user.Password}|{user.Username}|{user.Budget}";
        await File.AppendAllTextAsync(path, str);
    }

    Task IUserRepository.DeleteByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    private async Task<int> GenerateIdAsync()
    {
        var users = await RetrievAllAsync();
        if (users.Count() == 0)
            return 1;
        var lastId = users.Max(x => x.id);
        return ++lastId;
    }
}
