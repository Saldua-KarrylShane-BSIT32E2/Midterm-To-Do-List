namespace Todo.Repositories
{
    using Todo.Domain;
    using System;
    using System.Collections.Generic;

    public interface IUserRepository
    {
        User GetById(int userId);
        User GetByEmail(string email);
        List<User> GetAll();
        void Create(User user);
        void Update(User user);
        void Delete(int userId);
    }

    public class UserRepository : IUserRepository
    {
        private List<User> _users = new List<User>();

        public User GetById(int userId)
        {
            return _users.Find(u => u.UserId == userId);
        }

        public User GetByEmail(string email)
        {
            return _users.Find(u => u.Email == email);
        }

        public List<User> GetAll()
        {
            return _users;
        }

        public void Create(User user)
        {
            _users.Add(user);
        }

        public void Update(User user)
        {
            var existingUser = GetById(user.UserId);
            if (existingUser != null)
            {
                existingUser.Email = user.Email;
                existingUser.Password = user.Password;
                existingUser.IsLocked = user.IsLocked;
            }
            else
            {
                throw new InvalidOperationException("User not found.");
            }
        }

        public void Delete(int userId)
        {
            var user = GetById(userId);
            if (user != null)
            {
                _users.Remove(user);
            }
        }
    }
}