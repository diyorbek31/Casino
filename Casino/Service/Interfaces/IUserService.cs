using Casino.Domain.Entities;

namespace Casino.Service.Interfaces;

public interface IUserService
{
    public Task<bool> AddAsync(User user);
    public Task<bool> UpdateAsync(User user);
    public Task<bool> DeleteAsync(int id);
    public Task<User> GetByIdAsync(int id);
    public Task<IEnumerable<User>> SelectAllAsync();
}
