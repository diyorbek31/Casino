using Casino.Data.IRepositories;
using Casino.Data.Repositories;
using Casino.Domain.Entities;
using Casino.Service.Interfaces;
using Casino.Service.Exceptions;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace Casino.Service.Services;

public class UserService : IUserService
{
    IUserRepository userRepository = new UserRepository();
    public async Task<bool> AddAsync(User user)
    {
        var users = await this.userRepository.RetrievAllAsync();
        foreach (var person in users)
        {
            if (person.FirstName.ToLower() == user.FirstName.ToLower())
                throw new GameExceptions(404, "User already exists");
        }
        await this.userRepository.InsertAsync(user);
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var users = await this.userRepository.RetrievAllAsync();
        foreach (var person in users)
        {
            if (person.id == id)
            {
                await this.userRepository.DeleteByIdAsync(id);
                return true;
            }
        }
        throw new GameExceptions(404, "User not found");
    }

    
    public async  Task<User> GetByIdAsync(int id)
    {
        var person = await this.userRepository.RetrievByIdAsync(id);
        if (person is null)
            throw new GameExceptions(404, "User not found");
        return person;
    }

    public async Task<IEnumerable<User>> SelectAllAsync()
    {
        var users = await this.userRepository.RetrievAllAsync();
        if (users is null)
            throw new GameExceptions(404, "Users not found");
        return users;
    }

    public async Task<bool> UpdateAsync(User user)
    {
        var person = await this.userRepository.RetrievByIdAsync(user.id);
        if (person is null)
            throw new GameExceptions(404, "User not found");
        await this.userRepository.UpdateAsync(user);
        return true;
    }

    public async Task<decimal> GetBalanceAsync(int userId)
    {
        var human = await userRepository.RetrievByIdAsync(userId);

        if (human == null)
        {
            throw new GameExceptions(404, "User not found");
        }
               
        return human.Budget;
    }

}
