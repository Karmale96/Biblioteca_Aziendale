using System;
using Utility;

namespace Biblioteca_Aziendale.Models
{
    public class InPrestito : Entity
    {
        public InPrestito() { }

        public InPrestito(int id, DateOnly dataInizio, DateOnly dataFine, Utente idUtente, Libro idLibro): base(id)
        {
            DataInizio = dataInizio;
            DataFine = dataFine;
            IdUtente = idUtente;
            IdLibro = idLibro;
        }

        public DateOnly DataInizio { get; set; }
        public DateOnly DataFine { get; set; }
        public Utente IdUtente { get; set; }
        public Libro IdLibro { get; set; }
    }
}