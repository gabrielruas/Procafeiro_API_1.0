using DataAccess.Repositorios.Contratos;
using Dominio;
namespace DataAccess.Repositorios
{
    public class PanhaRepositorio : IPanhaRepositorio
    {
        private readonly Contexto _contexto;

        public PanhaRepositorio(Contexto contexto)
        {
            _contexto = contexto;
        }
        ///Adicionando Inicio /////
         public Panha ObterPorId(int panhaID)
        { 
            return _contexto.Panha.FirstOrDefault(panha => panha.IdPanha == panhaID);
        }
        // Fim //////
        public void AdicionarPanha(Panha panha)
        {
            _contexto.Panha.Add(panha);
            _contexto.SaveChanges();
        }

        public void AtualizarPanha(Panha panha)
        {
            _contexto.Panha.Update(panha);
            _contexto.SaveChanges();
        }
        public void RemoverPanha(Panha panha)
        {
            _contexto.Panha.Remove(panha);
            _contexto.SaveChanges();
        }
        public IEnumerable<Panha> ListarTodos()
        {
            return _contexto.Panha.ToList();
        }
    }
}