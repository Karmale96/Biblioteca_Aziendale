using System;
using Utility;

namespace Biblioteca_Aziendale.Models
{
    public class InPrestito : Entity
    {
        public InPrestito() { }


        public DateTime DataInizio { get; set; }
        public DateTime DataFine { get; set; }
        public int IdUtente { get; set; }
        public int IdLibro { get; set; }
    }
}