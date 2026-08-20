using DataAccess.Repositorios.Contratos;
using Dominio;

namespace DataAccess.Repositorios;

public class AlunoRepositorio : IAlunoRepositorio
{
    private readonly Contexto _contexto;

    public AlunoRepositorio(Contexto contexto)
    {
        _contexto = contexto;
    }

    public IEnumerable<Aluno> ListarTodos() => _contexto.Alunos.ToList();

    public Aluno ObterPorId(int idAluno) =>
        _contexto.Alunos.FirstOrDefault(aluno => aluno.IdAluno == idAluno);

    public void AdicionarAluno(Aluno aluno)
    {
        _contexto.Alunos.Add(aluno);
        _contexto.SaveChanges();
    }
}
