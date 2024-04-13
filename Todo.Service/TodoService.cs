using Todo.Domain;
using Todo.Repositories;
using System;

namespace Todo.Service
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Register(User userModel)
        {
            // Check if email already exists
            if (_userRepository.GetByEmail(userModel.Email) != null)
            {
                throw new InvalidOperationException("Email already exists.");
            }

            // Add user
            _userRepository.Create(userModel);
        }

        public void ChangePassword(int userId, string newPassword)
        {
            var user = _userRepository.GetById(userId);
            if (user != null)
            {
                user.Password = newPassword;
                _userRepository.Update(user);
            }
            else
            {
                throw new InvalidOperationException("User not found.");
            }
        }

        public bool Login(string email, string password)
        {
            var user = _userRepository.GetByEmail(email);
            return user != null && user.Password == password && !user.IsLocked;
        }

        public void LockAccount(int userId)
        {
            var user = _userRepository.GetById(userId);
            if (user != null)
            {
                user.IsLocked = true;
                _userRepository.Update(user);
            }
            else
            {
                throw new InvalidOperationException("User not found.");
            }
        }
    }
}
