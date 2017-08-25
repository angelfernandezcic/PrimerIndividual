using System.Linq;

namespace PrimerIndividual.Repository
{
    public interface IEntradaRepository
    {
        Entrada Create(Entrada entrada);
        Entrada Delete(long id);
        IQueryable<Entrada> Get();
        Entrada Get(long Id);
        void Put(Entrada entrada);
    }
}