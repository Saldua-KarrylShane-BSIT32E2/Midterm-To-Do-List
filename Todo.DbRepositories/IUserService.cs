using System.Threading.Tasks;
using Todo.Models; // Assuming User model is in this namespace

namespace Todo.DbRepositories
{
    public interface IUserService
    {
        Task<User> RegisterAsync(RegisterModel model);
        Task<User> LoginAsync(LoginModel model);
        Task ChangePasswordAsync(int userId, ChangePasswordModel model);
        Task LockAccountAsync(int userId);
    }
}
