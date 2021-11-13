using Microsoft.EntityFrameworkCore;

namespace RazorWeb3.Models
{
  public class BlogContext : DbContext
  {
    public BlogContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
    }

    public DbSet<Article> Articles { get; set; }
  }
}