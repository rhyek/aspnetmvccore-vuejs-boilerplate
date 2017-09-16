using Microsoft.EntityFrameworkCore;
using api.Database.Models;

namespace api.Database
{
  public class ApplicationDbContext : DbContext
  {
    public DbSet<User> Users { get; set; }
    
    public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options): base(options) {}
  }
}