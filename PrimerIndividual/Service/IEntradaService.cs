using System.Linq;

namespace PrimerIndividual.Service
{
    public interface IEntradaService
    {
        Entrada Create(Entrada entrada);
        Entrada Delete(long id);
        IQueryable<Entrada> Get();
        Entrada Get(long Id);
        void Put(Entrada entrada);
    }
}