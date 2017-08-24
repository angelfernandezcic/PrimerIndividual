using PrimerIndividual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimerIndividual.Repository
{
    public class EntradaRepository
    {
        public Entrada Create(Entrada entrada)
        {
            return ApplicationDbContext.applicationDbContext.CuentasBancarias.Add(entrada);
        }
        
        public Entrada Get(long Id)
        {
            return ApplicationDbContext.applicationDbContext.CuentasBancarias.Find(Id);
        }

        public IQueryable<Entrada> Get()
        {
            IList<Entrada> lista = new List<Entrada>(ApplicationDbContext.applicationDbContext.CuentasBancarias);
            return lista.AsQueryable();
        }

        public void Put(Entrada entrada)
        {
            if (ApplicationDbContext.applicationDbContext.CuentasBancarias.Count(e => e.Id == entrada.Id) == 0)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }
            ApplicationDbContext.applicationDbContext.Entry(entrada).State = EntityState.Modified;
        }

        public Entrada Delete(long id)
        {
            Entrada entrada = ApplicationDbContext.applicationDbContext.CuentasBancarias.Find(id);
            if (entrada == null)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }

            ApplicationDbContext.applicationDbContext.CuentasBancarias.Remove(entrada);
            return entrada;
        }
    }
}