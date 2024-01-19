using Microsoft.EntityFrameworkCore;
using Pattern.Models;

namespace Pattern.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
       
        public DbSet<User> Users { get; set; }
        public DbSet<InformationRequest> Information { get; set; }
    }
}
