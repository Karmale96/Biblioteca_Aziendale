using System;
using Utility;

namespace Biblioteca_Aziendale.Models
{
    public class ScrittoDa : Entity
    {
        public ScrittoDa() { }

        public Libro IdLibro { get; set; }
        public Autore IdAutore { get; set; }
    }
}

