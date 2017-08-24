using System.Linq;

namespace PrimerIndividual.Service
{
    public interface IPeliculaService
    {
        Pelicula Create(Pelicula pelicula);
        Pelicula Delete(long id);
        IQueryable<Pelicula> Get();
        Pelicula Get(long Id);
        void Put(Pelicula pelicula);
    }
}