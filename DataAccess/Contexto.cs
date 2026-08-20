using Microsoft.EntityFrameworkCore;
using Dominio;
using DataAccess.Mapeamentos;

namespace DataAccess;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options)
        : base(options)
    {
    }

    public DbSet<Panha> Panha { get; set; }

    public DbSet<Aluno> Alunos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PanhaConfiguration());
        modelBuilder.ApplyConfiguration(new AlunoConfiguration());
    }
}