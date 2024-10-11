using IoTAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace IoTAPI.Data
{
    public class IoTAPIDbContext : DbContext
    {
        public IoTAPIDbContext(DbContextOptions<IoTAPIDbContext> options) : base(options)
        {

        }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<CatSub> CatSub { get; set; }
        public DbSet<Estoque> Estoque { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<SubCategoria> SubCategoria { get; set; }
        public DbSet<User> User { get; set; }

        public DbSet<UserEstoque> UserEstoque { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Categoria>()
                .HasIndex(c => c.Nome).IsUnique();
            modelBuilder.Entity<SubCategoria>()
                .HasIndex(s => s.Nome).IsUnique();
            modelBuilder.Entity<Produto>()
                .HasIndex(p => p.Nome).IsUnique();
        }

    }
}
