using Microsoft.EntityFrameworkCore;
using Furever.Entities.Models;
using Furever.Entities.Configurations;

namespace Furever.Entities
{
    public class AppDbContext : DbContext
    { 
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        // Create Database Tables Here
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Favorite> Favorites { get; set;}
        public DbSet<Refuge> Refuges { get; set; }
        public DbSet<User> Users { get; set; }


        // Ignore this part
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Favorite>()
               .HasKey(x => new { x.AnimalId, x.UserId });

            modelBuilder.Entity<Favorite>()
                .HasOne(a => a.Animal)
                .WithMany(af => af.Favorites)
                .HasForeignKey(a => a.AnimalId);

            modelBuilder.Entity<Favorite>()
                .HasOne(u => u.User)
                .WithMany(uf => uf.Favorites)
                .HasForeignKey(u => u.UserId);

            modelBuilder.ApplyConfiguration(new AnimalConfiguration());
            modelBuilder.ApplyConfiguration(new FavoriteConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RefugeConfiguration());
        }
    }
}
