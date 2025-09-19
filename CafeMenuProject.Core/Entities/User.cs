namespace CafeMenuProject.Core.Entities
{
    /// <summary>
    /// User entity
    /// </summary>
    public class User
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string HashPassword { get; set; }

        public string SaltPassword { get; set; }
    }
}
