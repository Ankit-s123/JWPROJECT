using Microsoft.EntityFrameworkCore;

namespace JWPROJECT.Models
{
    public class JWContext : DbContext
    {

public JWContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Login> tbl_login { get; set; }
        public DbSet<Project> tbl_project { get; set; }
        public DbSet<User> tbl_user { get; set; }
        public DbSet<Contact> tbl_contact { get; set; }
        public DbSet<Branch> tbl_branch { get; set; }
    }
}
