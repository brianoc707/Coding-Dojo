using Microsoft.EntityFrameworkCore;
 
namespace LoginReg.Models
{
    public class MyContext : DbContext
    {
        
            
            // "users" table is represented by this DbSet "Users"
        public DbSet<User> Users {get;set;}
        public MyContext(DbContextOptions options) : base(options) { }
    }
}