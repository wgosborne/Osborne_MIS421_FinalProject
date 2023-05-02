using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using _521Final.Models;

namespace _521Final.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<_521Final.Models.Reccomendation>? Reccomendation { get; set; }
        public DbSet<Book>? Book { get; set; }
        public DbSet<_521Final.Models.Genre>? Genre { get; set; }
        public DbSet<_521Final.Models.GenreBook>? GenreBook { get; set; }
        public DbSet<_521Final.Models.UserBook>? UserBook { get; set; }
        public DbSet<User>? User { get; set; }
        public DbSet<ApplicationUser>? ApplicationUser { get; set; }

    }
}