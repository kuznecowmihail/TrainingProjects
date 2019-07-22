using System.Data.Entity;

namespace AccountLogInApplication
{
    public class UserContext : DbContext
    {
        public UserContext() : base("connectionDB") { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}