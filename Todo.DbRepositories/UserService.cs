using System;
using System.Threading.Tasks;
using Todo.Models;
using BCrypt.Net;
using Todo.DbRepositories.Repositories;

namespace Todo.DbRepositories
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> RegisterAsync(RegisterModel model)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);
            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                HashedPassword = hashedPassword
                // Other properties
            };

            await _userRepository.CreateAsync(user);
            return user;
        }

        public async Task<User> LoginAsync(LoginModel model)
        {
            var user = await _userRepository.GetByEmailAsync(model.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.HashedPassword))
            {
                // Handle invalid credentials
                return null;
            }

            // Successful login
            return user;
        }

        public async Task ChangePasswordAsync(int userId, ChangePasswordModel model)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            if (!BCrypt.Net.BCrypt.Verify(model.OldPassword, user.HashedPassword))
            {
                throw new Exception("Incorrect old password.");
            }

            string newHashedPassword = BCrypt.Net.BCrypt.HashPassword(model.NewPassword);
            user.HashedPassword = newHashedPassword;
            await _userRepository.UpdateAsync(user);
        }

        public async Task LockAccountAsync(int userId)
        {
            // Implement lock account logic here
            throw new NotImplementedException();
        }
    }
}
