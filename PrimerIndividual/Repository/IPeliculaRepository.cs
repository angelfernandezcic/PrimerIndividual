using System.Linq;

namespace PrimerIndividual.Repository
{
    public interface IPeliculaRepository
    {
        Pelicula Create(Pelicula pelicula);
        Pelicula Delete(long id);
        IQueryable<Pelicula> Get();
        Pelicula Get(long Id);
        void Put(Pelicula pelicula);
    }
}