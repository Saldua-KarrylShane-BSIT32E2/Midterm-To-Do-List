namespace Todo.Domain
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsLocked { get; set; }
    }
}