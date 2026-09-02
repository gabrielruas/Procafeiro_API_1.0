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

    // Yan - Esta função lista todos os alunos cadastrados no banco de dados.
    public IEnumerable<Aluno> ListarTodos() => _contexto.Alunos.ToList();

    // Yan - Esta função busca um aluno pelo seu ID.
    public Aluno ObterPorId(int idAluno) =>
        _contexto.Alunos.FirstOrDefault(aluno => aluno.IdAluno == idAluno);

    // Yan - Esta função adiciona um novo aluno ao banco de dados.
    public void AdicionarAluno(Aluno aluno)
    {
        _contexto.Alunos.Add(aluno);
        _contexto.SaveChanges();
    }
}