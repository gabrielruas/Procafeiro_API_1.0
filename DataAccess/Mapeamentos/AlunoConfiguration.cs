using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Mapeamentos;

public class AlunoConfiguration : IEntityTypeConfiguration<Aluno>
{
    public void Configure(EntityTypeBuilder<Aluno> builder)
    {
        builder.ToTable("Alunos");

        builder.HasKey(aluno => aluno.IdAluno);

        builder.Property(aluno => aluno.IdAluno)
            .HasColumnName("IdAluno");

        builder.Property(aluno => aluno.Nome)
            .HasColumnName("Nome")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(aluno => aluno.Cidade)
            .HasColumnName("Cidade")
            .IsRequired();

        builder.Property(aluno => aluno.Idade) 
            .HasColumnName("Idade")
            .IsRequired();
    }
}