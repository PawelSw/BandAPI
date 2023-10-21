using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BandAPI.Entities
{
    public class BandDbContext : DbContext
    {
        public BandDbContext(DbContextOptions<BandDbContext> options) : base(options)
        {

        }

        public DbSet<Band> Bands { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(_connectionString);
        //}
    }
}

