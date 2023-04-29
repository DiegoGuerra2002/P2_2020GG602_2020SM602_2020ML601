using Microsoft.EntityFrameworkCore;
namespace P2_2020GG602_2020SM602_2020ML601.Models
{
    public class hospitalDbContext : DbContext 
    {
        public hospitalDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<departamento> departamentos { get; set;}
        public DbSet<casosreportados> casosreportados { get;set;}
        public DbSet<generos> generos { get; set;}

    }
}
