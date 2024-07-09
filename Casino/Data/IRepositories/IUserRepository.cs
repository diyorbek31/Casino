using Casino.Domain.Entities;

namespace Casino.Data.IRepositories;

public interface IUserRepository
{
    public Task<bool> InsertAsync(User user);
    public Task<bool> UpdateAsync(User user);
    public Task<bool> DeleteByIdAysnc(int id);
    public Task<User> RetrievByIdAsync(int id);
    public Task<List<User>> RetrievAllAsync();
    public Task WriteToFileAsync(User user);
    Task DeleteByIdAsync(int id);
}
