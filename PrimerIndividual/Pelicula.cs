using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimerIndividual
{
    public class Pelicula
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Director { get; set; }
        public int Duracion { get; set; }
        public bool Cartelera { get; set; }
    }
}