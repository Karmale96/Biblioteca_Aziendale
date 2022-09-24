using System;
using Utility;

namespace Biblioteca_Aziendale.Models
{
    public class InPrestito : Entity
    {
        public InPrestito() { }


        public DateOnly DataInizio { get; set; }
        public DateOnly DataFine { get; set; }
        public Utente IdUtente { get; set; }
        public Libro IdLibro { get; set; }
    }
}