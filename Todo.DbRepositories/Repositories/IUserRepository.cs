using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Models; // Assuming User model is in this namespace

namespace Todo.DbRepositories.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<User> GetByEmailAsync(string email);
        Task<IEnumerable<User>> GetAllAsync();
        Task CreateAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
    }
}
