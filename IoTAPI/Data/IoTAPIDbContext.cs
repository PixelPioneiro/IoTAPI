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

    }
}
