using CSharp_Entity_Framework.Models;
using Microsoft.EntityFrameworkCore;

namespace CSharp_Entity_Framework.DAL
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string connectionString = @"Server=127.0.0.1;Database=BLogPost;User Id=sa;Password=MyPass@word;";
            optionsBuilder.UseSqlServer(connectionString);
        }
        public DbSet<Post> Posts { get; set; }
        
    }
}