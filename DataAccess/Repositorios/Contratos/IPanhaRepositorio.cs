using Dominio;
using System.Collections.Generic;

namespace DataAccess.Repositorios.Contratos
{
    public interface IPanhaRepositorio
    {
        void AdicionarPanha(Panha panha);
        void AtualizarPanha(Panha panha);
        void RemoverPanha(Panha panha);
        IEnumerable<Panha> ListarTodos();
        //// adicionando 
        Panha ObterPorId(int panhaID);
    }
}