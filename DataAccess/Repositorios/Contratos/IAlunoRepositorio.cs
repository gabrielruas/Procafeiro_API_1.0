using Dominio;

namespace DataAccess.Repositorios.Contratos;

public interface IAlunoRepositorio
{
    IEnumerable<Aluno> ListarTodos();
    Aluno ObterPorId(int idAluno);
    void AdicionarAluno(Aluno aluno);
}
