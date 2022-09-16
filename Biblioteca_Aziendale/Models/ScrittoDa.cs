using System;
using Utility;

namespace Biblioteca_Aziendale.Models
{
    public class ScrittoDa : Entity
    {
        public ScrittoDa() { }

        public ScrittoDa(int id, Libro idLibro, Autore idAutore) : base(id)
        {
            IdLibro = idLibro;
            IdAutore = idAutore;
        }

        public Libro IdLibro { get; set; }
        public Autore IdAutore { get; set; }
    }
}

