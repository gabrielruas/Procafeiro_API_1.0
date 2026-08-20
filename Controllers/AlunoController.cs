using DataAccess.Repositorios.Contratos;
using Dominio;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AlunoController : ControllerBase
{
    private readonly IAlunoRepositorio _alunoRepositorio;

    public AlunoController(IAlunoRepositorio alunoRepositorio)
    {
        _alunoRepositorio = alunoRepositorio;
    }

    [HttpGet]
    public IActionResult ListarAlunos() => Ok(_alunoRepositorio.ListarTodos());

    [HttpGet("{idAluno}")]
    public IActionResult ObterPorId(int idAluno)
    {
        var aluno = _alunoRepositorio.ObterPorId(idAluno);
        return aluno == null ? NotFound() : Ok(aluno);
    }

    [HttpPost]
    public IActionResult Adicionar([FromBody] Aluno aluno)
    {
        _alunoRepositorio.AdicionarAluno(aluno);
        return CreatedAtAction(nameof(ObterPorId),
            new { idAluno = aluno.IdAluno }, aluno);
    }
}
