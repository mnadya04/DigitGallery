namespace DigitGallery.Data
{
    using DigitGallery.Models;
    using Microsoft.EntityFrameworkCore;
    public class AppDbContext : DbContext
    {
        private const string ConnectionString = "Server=.;Database=DigitGalleryDb;Trusted_Connection=True;";

        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Drawing> Drawings { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
                optionsBuilder.UseLazyLoadingProxies();
            }
        }
    }
}
