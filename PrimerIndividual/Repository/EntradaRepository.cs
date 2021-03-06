﻿using PrimerIndividual.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PrimerIndividual.Repository
{
    public class EntradaRepository : IEntradaRepository
    {
        public Entrada Create(Entrada entrada)
        {
            return ApplicationDbContext.applicationDbContext.Entradas.Add(entrada);
        }
        
        public Entrada Get(long Id)
        {
            return ApplicationDbContext.applicationDbContext.Entradas.Find(Id);
        }

        public IQueryable<Entrada> Get()
        {
            IList<Entrada> lista = new List<Entrada>(ApplicationDbContext.applicationDbContext.Entradas);
            return lista.AsQueryable();
        }

        public void Put(Entrada entrada)
        {
            if (ApplicationDbContext.applicationDbContext.Entradas.Count(e => e.Id == entrada.Id) == 0)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }
            ApplicationDbContext.applicationDbContext.Entry(entrada).State = EntityState.Modified;
        }

        public Entrada Delete(long id)
        {
            Entrada entrada = ApplicationDbContext.applicationDbContext.Entradas.Find(id);
            if (entrada == null)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }

            ApplicationDbContext.applicationDbContext.Entradas.Remove(entrada);
            return entrada;
        }
    }
}