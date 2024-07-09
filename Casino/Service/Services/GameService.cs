using Casino.Domain.Entities;
using Casino.Service.Exceptions;
using Casino.Service.Interfaces;

namespace Casino.Service.Services;

public class GameService : IGameService
{
    UserService userService = new UserService();
    private static Random random = new Random();
    
    public  Task<decimal> CalculateWinnigsAsync(decimal betAmount, User user)
    {
        user.Budget +=  betAmount * 2;
        return Task.FromResult(user.Budget);
    }

   

    public async Task<bool> PlayBetAsync(decimal amount,User user)
    {
        var humans = await this.userService.SelectAllAsync();
        foreach(var item in humans)
        {
            if(item.id == user.id) 
            {
                if (amount > user.Budget)
                {
                    throw new GameExceptions(403, "Insufficient balance to place the bet");
                }
            }
        }
                
        user.Budget -= amount;
        this.userService.UpdateAsync(user);
        return true;
    }

    public async Task<bool> PlayerIsAvailable(int id)
    {
        var users = await userService.SelectAllAsync();
        foreach (var user in users) 
        { 
            if(user.id == id)
            {
                return true;
            }
        }
        throw new GameExceptions(404, "User not found");
    }

    public  Task<bool> PlayGameAsync(int guessNumber)
    {
        var compNum = random.Next(1, 10);
        if(guessNumber == compNum)
        {
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    public async Task<decimal> GetBalance(int id)
    {
        var userBalance = await userService.GetBalanceAsync(id);
        return userBalance;
    }
}
    