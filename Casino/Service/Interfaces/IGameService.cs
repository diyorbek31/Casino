using Casino.Domain.Entities;

namespace Casino.Service.Interfaces;

public interface IGameService
{
    public Task<decimal> CalculateWinnigsAsync(decimal betAmount, User user );
    public Task<bool> PlayGameAsync(int guessNumber);
    public Task<bool> PlayBetAsync(decimal amount,User user);
    public Task<bool> PlayerIsAvailable(int id);
    public Task<decimal> GetBalance(int id);
}
