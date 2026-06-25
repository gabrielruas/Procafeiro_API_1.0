using Microsoft.AspNetCore.Mvc;
using Dominio;
using DataAccess.Repositorios.Contratos;


[Route("api/[controller]")]
[ApiController]
public class PanhaController : ControllerBase
{
    private readonly IPanhaRepositorio _panhaRepositorio;

    public PanhaController(IPanhaRepositorio panhaRepositorio)
    {
        _panhaRepositorio = panhaRepositorio;
    }

    [HttpGet]
    public IActionResult ListarPanhas()
    {
        var panhas = _panhaRepositorio.ListarTodos();

        if (!panhas.Any())
            return NoContent();

        return Ok(panhas);
    }
    
    [HttpGet("{panhaID}")]
    public IActionResult Get(int panhaID)
    {
        var panha = _panhaRepositorio.ObterPorId(panhaID);

        if (panha == null)
            return NotFound();

        return Ok(panha);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Panha panha)
    {
        _panhaRepositorio.AdicionarPanha(panha);
        return CreatedAtAction(nameof(Get), new {panhaID = panha.IdPanha}, panha);
    }
}