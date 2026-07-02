using Microsoft.EntityFrameworkCore;
using Dominio;

namespace DataAccess;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options)
        : base(options)
    {
    }

    public DbSet<Panha> Panha { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PanhaConfiguration());
    }
}
